using System.IO;
using System.Linq;
using Intent.Engine;
using Intent.Modelers.Domain.Api;
using Intent.Modules.Ardalis.Repositories.Templates;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp.Builder;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Plugins;
using Intent.Modules.Common.Templates;
using Intent.Modules.Constants;
using Intent.Modules.Entities.Repositories.Api.Templates;
using Intent.Modules.Entities.Repositories.Api.Templates.EntityRepositoryInterface;
using Intent.Modules.EntityFrameworkCore.Repositories.Templates;
using Intent.Modules.EntityFrameworkCore.Repositories.Templates.Repository;
using Intent.Plugins.FactoryExtensions;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.FactoryExtension", Version = "1.0")]

namespace Intent.Modules.Ardalis.Repositories.FactoryExtensions
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    public class RepositoryFactoryExtension : FactoryExtensionBase
    {
        public override string Id => "Ardalis.Repositories.RepositoryFactoryExtension";

        [IntentManaged(Mode.Ignore)]
        public override int Order => 0;

        /// <summary>
        /// This is an example override which would extend the
        /// <see cref="ExecutionLifeCycleSteps.Start"/> phase of the Software Factory execution.
        /// See <see cref="FactoryExtensionBase"/> for all available overrides.
        /// </summary>
        /// <remarks>
        /// It is safe to update or delete this method.
        /// </remarks>
        protected override void OnBeforeTemplateExecution(IApplication application)
        {
            var repoInterfaceTemplates = application.FindTemplateInstances<CSharpTemplateBase<ClassModel>>(TemplateDependency.OnTemplate(EntityRepositoryInterfaceTemplate.TemplateId));
            foreach (var template in repoInterfaceTemplates)
            {
                template.AddNugetDependency(NugetPackages.ArdalisSpecification);
                
                ((ICSharpFileBuilderTemplate)template).CSharpFile.AfterBuild(file =>
                {
                    var @interface = file.Interfaces.First();
                    var model = @interface.GetMetadata<ClassModel>("model");
                    @interface.Interfaces.Clear();
                    @interface.Methods.Clear();
                    @interface.ExtendsInterface($"IRepositoryBase<{GetEntityStateName(template)}>");
                    @interface.ExtendsInterface(template.GetReadRepositoryInterfaceName(model));
                    file.AddUsing("Ardalis.Specification");
                    
                    @interface.AddProperty(template.GetUnitOfWorkInterfaceName(), "UnitOfWork", prop =>
                    {
                        prop.ReadOnly();
                    });

                    @interface.AddMethod("void", "Add", method =>
                    {
                        method.AddParameter(GetEntityStateName(template), "entity");
                    });
                    
                    @interface.AddMethod("void", "Remove", method =>
                    {
                        method.AddParameter(GetEntityStateName(template), "entity");
                    });
                });
            }

            var entityRepoTemplates = application.FindTemplateInstances<CSharpTemplateBase<ClassModel>>(TemplateDependency.OnTemplate(RepositoryTemplate.TemplateId));
            foreach (var template in entityRepoTemplates)
            {
                template.AddNugetDependency(NugetPackages.ArdalisSpecificationEntityFrameworkCore);
                
                ((ICSharpFileBuilderTemplate)template).CSharpFile.AfterBuild(file =>
                {
                    file.AddUsing("System");
                    file.AddUsing("System.Collections.Generic");
                    file.AddUsing("System.Linq");
                    file.AddUsing("System.Linq.Expressions");
                    file.AddUsing("System.Threading");
                    file.AddUsing("System.Threading.Tasks");
                    file.AddUsing("Ardalis.Specification");
                    file.AddUsing("Ardalis.Specification.EntityFrameworkCore");
                    file.AddUsing("Microsoft.EntityFrameworkCore");

                    var @class = file.Classes.First();
                    var model = @class.GetMetadata<ClassModel>("model");
                    @class.Interfaces.Clear();
                    @class.Methods.Clear();
                    @class.WithBaseType($"RepositoryBase<{GetEntityStateName(template)}>");
                    @class.ImplementsInterface(template.GetEntityRepositoryInterfaceName(model));

                    var dbContextType = template.TryGetTypeName("Infrastructure.Data.DbContext", out var dbContextName) ? dbContextName : $"{model.Application.Name}DbContext";
                    @class.AddField(dbContextType, "_dbContext", field => field.PrivateReadOnly());

                    var ctor = @class.Constructors.First();
                    ctor.AddStatement($"_dbContext = dbContext;");

                    @class.AddProperty(template.GetUnitOfWorkInterfaceName(), "UnitOfWork", prop =>
                    {
                        prop.ReadOnly();
                        prop.Getter.WithExpressionImplementation("_dbContext");
                    });
                    
                    @class.AddMethod("void", "Add", method =>
                    {
                        method.AddAttribute("[IntentManaged(Mode.Fully)]");
                        method.AddParameter(GetEntityStateName(template), "entity");
                        method.AddStatement("base.AddAsync(entity).Wait();");
                    });
                    
                    @class.AddMethod("void", "Remove", method =>
                    {
                        method.AddAttribute("[IntentManaged(Mode.Fully)]");
                        method.AddParameter(GetEntityStateName(template), "entity");
                        method.AddStatement("base.DeleteAsync(entity).Wait();");
                    });

                    if (HasSinglePrimaryKey(template))
                    {
                        @class.AddMethod($"Task<{GetEntityInterfaceName(template)}>", "FindByIdAsync", method =>
                        {
                            method.AddAttribute("[IntentManaged(Mode.Fully)]");
                            method.Async();
                            method.AddParameter(GetSurrogateKey(template), "id")
                                .AddParameter("CancellationToken", "cancellationToken", param => param.WithDefaultValue("default"));
                            method.AddStatement($"return await GetByIdAsync(id: id, cancellationToken: cancellationToken);");
                        });
                        @class.AddMethod($"Task<List<{GetEntityInterfaceName(template)}>>", "FindByIdsAsync", method =>
                        {
                            method.AddAttribute("[IntentManaged(Mode.Fully)]");
                            method.Async();
                            method.AddParameter($"{GetSurrogateKey(template)}[]", "ids")
                                .AddParameter("CancellationToken", "cancellationToken", param => param.WithDefaultValue("default"));
                            if (GetEntityStateName(template) == GetEntityInterfaceName(template))
                            {
                                method.AddStatement($"return await ListAsync(specification: new FindByIdsSpecification(ids), cancellationToken: cancellationToken);");
                            }
                            else
                            {
                                method.AddStatement($"return (await ListAsync(specification: new FindByIdsSpecification(ids), cancellationToken: cancellationToken)).Cast<{GetEntityInterfaceName(template)}>().ToList();");
                            }
                        });
                        
                        @class.AddNestedClass("FindByIdsSpecification", nested =>
                        {
                            nested.AddAttribute("[IntentManaged(Mode.Fully)]");
                            nested.Private();
                            nested.Sealed();
                            nested.ExtendsClass($"Specification<{GetEntityStateName(template)}>");
                            nested.AddConstructor(ctor =>
                            {
                                ctor.AddParameter($"{GetSurrogateKey(template)}[]", "ids");
                                ctor.AddStatement("Query.Where(p => ids.Contains(p.Id));");
                            });
                        });
                    }

                    @class.AddMethod(
                        $"Task<List<{GetEntityInterfaceName(template)}>>", 
                        "FindAllAsync",
                        method =>
                        {
                            method.AddAttribute("[IntentManaged(Mode.Fully)]");
                            method.Async();
                            method.AddParameter("CancellationToken", "cancellationToken", param => param.WithDefaultValue("default"));
                            method.AddStatement($"return await ListAsync(cancellationToken);");
                        });

                    @class.AddMethod(
                        $"Task<{template.GetPagedResultInterfaceName()}<{GetEntityInterfaceName(template)}>>", 
                        "FindAllAsync", 
                        method =>
                        {
                            method.AddAttribute("[IntentManaged(Mode.Fully)]");
                            method.AddParameter("int", "pageNo")
                                .AddParameter("int", "pageSize")
                                .AddParameter("CancellationToken", "cancellationToken", param => param.WithDefaultValue("default"));
                            method.AddStatement($"return FindAllAsync(filterExpression: x => true, pageNo: pageNo, pageSize: pageSize, cancellationToken: cancellationToken);");
                        });
                    
                    @class.AddMethod(
                        $"Task<{template.GetPagedResultInterfaceName()}<{GetEntityInterfaceName(template)}>>", 
                        "FindAllAsync", 
                        method =>
                        {
                            method.AddAttribute("[IntentManaged(Mode.Fully)]");
                            method
                                .AddParameter($"Expression<Func<{GetEntityStateName(template)}, bool>>", "filterExpression")
                                .AddParameter("int", "pageNo")
                                .AddParameter("int", "pageSize")
                                .AddParameter("CancellationToken", "cancellationToken", param => param.WithDefaultValue("default"));
                            method.AddStatement($"return FindAllAsync(filterExpression: filterExpression, pageNo: pageNo, pageSize: pageSize, linq: x => x, cancellationToken: cancellationToken);");
                        });
                    
                    @class.AddMethod(
                        $"Task<{template.GetPagedResultInterfaceName()}<{GetEntityInterfaceName(template)}>>", 
                        "FindAllAsync", 
                        method =>
                        {
                            method.AddAttribute("[IntentManaged(Mode.Fully)]");
                            method.Async();
                            method
                                .AddParameter($"Expression<Func<{GetEntityStateName(template)}, bool>>", "filterExpression")
                                .AddParameter("int", "pageNo")
                                .AddParameter("int", "pageSize")
                                .AddParameter($"Func<IQueryable<{GetEntityStateName(template)}>, IQueryable<{GetEntityStateName(template)}>>", "linq")
                                .AddParameter("CancellationToken", "cancellationToken", param => param.WithDefaultValue("default"));
                            method.AddStatement($"IQueryable<{GetEntityStateName(template)}> queryable = _dbContext.Set<{GetEntityStateName(template)}>();")
                                .AddStatement($"queryable = queryable.Where(filterExpression);")
                                .AddStatement($"var result = linq(queryable);")
                                .AddStatement(new CSharpInvocationStatement($"return await PagedList<{GetEntityStateName(template)}>.CreateAsync")
                                    .AddArgument("result")
                                    .AddArgument("pageNo")
                                    .AddArgument("pageSize")
                                    .AddArgument("cancellationToken")
                                    .WithArgumentsOnNewLines());
                        });

                    @class.AddMethod("Task<int>", "SaveChangesAsync", method =>
                    {
                        method.AddAttribute("[IntentManaged(Mode.Fully)]");
                        method.WithComments("// To avoid escalating db locks early, we are not going to perform saving changes on every operation.")
                            .WithComments("// The overall infrastructure will ensure that the DbContext SaveChanges is ultimately invoked.");
                        method.Override();
                        method.AddParameter("CancellationToken", "cancellationToken", param => param.WithDefaultValue("default"));
                        method.AddStatement($"return Task.FromResult(0);");
                    });

                    @class.AddMethod("Task<int>", $"IRepositoryBase<{GetEntityStateName(template)}>.SaveChangesAsync", method =>
                    {
                        method.AddAttribute("[IntentManaged(Mode.Fully)]");
                        method.WithoutAccessModifier();
                        method.WithComments("// In the event that SaveChanges is invoked explicitly, it should still operate as intended. ");
                        method.AddParameter("CancellationToken", "cancellationToken", param => param.WithDefaultValue("default"));
                        method.AddStatement("return base.SaveChangesAsync(cancellationToken);");
                    });
                });
            }
        }
        
        private string GetEntityStateName(CSharpTemplateBase<ClassModel> template) => template.GetTypeName("Domain.Entity", template.Model);

        private string GetEntityInterfaceName(CSharpTemplateBase<ClassModel> template) => template.GetTypeName("Domain.Entity.Interface", template.Model);
        
        private bool HasSinglePrimaryKey(CSharpTemplateBase<ClassModel> template)
        {
            if (!template.TryGetTemplate<ICSharpFileBuilderTemplate>(TemplateFulfillingRoles.Domain.Entity.Primary, template.Model, out var entityTemplate))
            {
                return false;
            }

            return entityTemplate.CSharpFile.Classes.First().HasSinglePrimaryKey();
        }

        private string GetSurrogateKey(CSharpTemplateBase<ClassModel> template)
        {
            if (!template.TryGetTemplate<ICSharpFileBuilderTemplate>(TemplateFulfillingRoles.Domain.Entity.Primary, template.Model, out var entityTemplate))
            {
                return string.Empty;
            }

            return template.UseType(entityTemplate.CSharpFile.Classes.First().GetPropertyWithPrimaryKey().Type);
        }
    }
}