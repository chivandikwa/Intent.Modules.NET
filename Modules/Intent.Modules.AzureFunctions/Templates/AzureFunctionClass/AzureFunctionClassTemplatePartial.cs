using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Intent.AzureFunctions.Api;
using Intent.Engine;
using Intent.Modelers.Services.Api;
using Intent.Modules.Application.Dtos.Templates;
using Intent.Modules.Application.Dtos.Templates.DtoModel;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.CSharp.Templates.CSharpTemplatePartial", Version = "1.0")]

namespace Intent.Modules.AzureFunctions.Templates.AzureFunctionClass
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    partial class AzureFunctionClassTemplate : CSharpTemplateBase<OperationModel, AzureFunctionClassDecorator>
    {
        public const string TemplateId = "Intent.AzureFunctions.AzureFunctionClass";

        private readonly bool _hasMultipleServices;

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public AzureFunctionClassTemplate(IOutputTarget outputTarget, OperationModel model) : base(TemplateId, outputTarget, model)
        {
            AddNugetDependency(NugetPackages.MicrosoftNETSdkFunctions);
            AddNugetDependency(NugetPackages.MicrosoftExtensionsDependencyInjection);
            AddNugetDependency(NugetPackages.MicrosoftExtensionsHttp);
            AddNugetDependency(NugetPackages.MicrosoftAzureFunctionsExtensions);

            AddTypeSource(DtoModelTemplate.TemplateId, "List<{0}>");
        }

        public AzureFunctionClassTemplate(IOutputTarget outputTarget, OperationModel model, bool hasMultipleServices)
            : this(outputTarget, model)
        {
            _hasMultipleServices = hasMultipleServices;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        protected override CSharpFileConfig DefineFileConfig()
        {
            return new CSharpFileConfig(
                className: $"{Model.Name}",
                @namespace: $"{this.GetNamespace()}",
                relativeLocation: GetRelativeLocation());
        }

        private string GetRelativeLocation()
        {
            return _hasMultipleServices
                ? Path.Join(this.GetFolderPath(), Model.ParentService.Name)
                : this.GetFolderPath();
        }

        private string GetClassEntryDefinitionList()
        {
            var definitionList = new List<string>();

            definitionList.AddRange(GetDecorators()
                .OrderBy(o => o.Priority)
                .SelectMany(s => s.GetClassEntryDefinitionList()));

            return string.Join(@"
        ", definitionList);
        }

        private string GetConstructorParameterDefinitionList()
        {
            var paramList = new List<string>();

            paramList.AddRange(GetDecorators()
                .OrderBy(o => o.Priority)
                .SelectMany(s => s.GetConstructorParameterDefinitionList()));

            const string newLine = @"
            ";
            return newLine + string.Join("," + newLine, paramList);
        }

        private string GetConstructorBodyStatementList()
        {
            var statementList = new List<string>();

            statementList.AddRange(GetDecorators()
                .OrderBy(o => o.Priority)
                .SelectMany(s => s.GetConstructorBodyStatementList()));

            const string newLine = @"
            ";
            return string.Join(newLine, statementList);
        }

        private string GetRunMethodParameterDefinitionList()
        {
            var paramList = new List<string>();

            if (Model.HasHttpTrigger())
            {
                var method = @$"""{Model.GetHttpTrigger().Method().Value.ToLower()}""";
                var route = !string.IsNullOrWhiteSpace(Model.GetHttpTrigger().Route())
                    ? $@"""{Model.GetHttpTrigger().Route()}"""
                    : "null";
                paramList.Add(
                    @$"[HttpTrigger(AuthorizationLevel.{Model.GetHttpTrigger().AuthorizationLevel().Value}, {method}, Route = {route})] HttpRequest req");
            }

            paramList.Add("ILogger log");

            paramList.AddRange(GetDecorators()
                .OrderBy(o => o.Priority)
                .SelectMany(s => s.GetRunMethodParameterDefinitionList()));

            if (paramList.Count == 0)
            {
                throw new Exception($"Operation {Model.Name} has no Azure Function Trigger specified");
            }

            const string newLine = @"
            ";
            return newLine + string.Join("," + newLine, paramList);
        }

        private string GetRunMethodEntryStatementList()
        {
            var statementList = new List<string>();

            foreach (var param in GetQueryParams())
            {
                statementList.Add(
                    $@"var {param.Name.ToParameterName()} = req.Query[""{param.Name.ToCamelCase()}""];");
            }

            if (!string.IsNullOrWhiteSpace(GetRequestDtoType()))
            {
                statementList.Add($@"string requestBody = await new StreamReader(req.Body).ReadToEndAsync();");
                statementList.Add($@"var dto = JsonConvert.DeserializeObject<{GetRequestDtoType()}>(requestBody);");
            }

            statementList.AddRange(GetDecorators()
                .OrderBy(o => o.Priority)
                .SelectMany(s => s.GetRunMethodEntryStatementList()));

            const string newLine = @"
            ";
            return string.Join(newLine, statementList);
        }

        private string GetRunMethodBodyStatementList()
        {
            var statementList = new List<string>();

            statementList.AddRange(GetDecorators()
                .OrderBy(o => o.Priority)
                .SelectMany(s => s.GetRunMethodBodyStatementList()));

            const string newLine = @"
            ";
            return string.Join(newLine, statementList);
        }

        private string GetRunMethodExitStatementList()
        {
            var statementList = new List<string>();

            statementList.AddRange(GetDecorators()
                .OrderBy(o => o.Priority)
                .SelectMany(s => s.GetRunMethodExitStatementList()));

            const string newLine = @"
            ";
            return string.Join(newLine, statementList);
        }

        private string GetRequestDtoType()
        {
            var dtoParams = Model.Parameters
                .Where(p => p.TypeReference.Element.IsDTOModel())
                .ToArray();
            switch (dtoParams.Length)
            {
                case 0:
                    return null;
                case > 1:
                    throw new Exception($"Multiple DTOs not supported on {Model.Name} operation");
                default:
                    {
                        var param = dtoParams.First();
                        return this.GetDtoModelName(param.TypeReference.Element.AsDTOModel());
                    }
            }
        }

        private IReadOnlyCollection<ParameterModel> GetQueryParams()
        {
            return Model.Parameters.Where(p => !p.TypeReference.Element.IsDTOModel()).ToArray();
        }
    }
}