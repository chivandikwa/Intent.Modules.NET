// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Entities.Repositories.Api.Templates.RepositoryInterface
{
    using Intent.Modelers.Domain.Api;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.CSharp.Templates;
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities.Repositories.Api\Templates\RepositoryInterface\RepositoryInterfaceTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class RepositoryInterfaceTemplate : CSharpTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing Syste" +
                    "m.Linq.Expressions;\r\nusing System.Threading;\r\nusing System.Threading.Tasks;\r\n\r\n[" +
                    "assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 23 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities.Repositories.Api\Templates\RepositoryInterface\RepositoryInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public interface ");
            
            #line 25 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities.Repositories.Api\Templates\RepositoryInterface\RepositoryInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("<TDomain, TPersistence>\r\n    {\r\n        void Add(TDomain entity);\r\n        void R" +
                    "emove(TDomain entity);\r\n        Task<TDomain> FindAsync(Expression<Func<TPersist" +
                    "ence, bool>> filterExpression, CancellationToken cancellationToken = default);\r\n" +
                    "        Task<List<TDomain>> FindAllAsync(CancellationToken cancellationToken = d" +
                    "efault);\r\n        Task<List<TDomain>> FindAllAsync(Expression<Func<TPersistence," +
                    " bool>> filterExpression, CancellationToken cancellationToken = default);\r\n     " +
                    "   Task<List<TDomain>> FindAllAsync(Expression<Func<TPersistence, bool>> filterE" +
                    "xpression, Func<IQueryable<TPersistence>, IQueryable<TPersistence>> linq, Cancel" +
                    "lationToken cancellationToken = default);\r\n        Task<IPagedResult<TDomain>> F" +
                    "indAllAsync(int pageNo, int pageSize, CancellationToken cancellationToken = defa" +
                    "ult);\r\n        Task<IPagedResult<TDomain>> FindAllAsync(Expression<Func<TPersist" +
                    "ence, bool>> filterExpression, int pageNo, int pageSize, CancellationToken cance" +
                    "llationToken = default);\r\n        Task<IPagedResult<TDomain>> FindAllAsync(Expre" +
                    "ssion<Func<TPersistence, bool>> filterExpression, int pageIndex, int pageSize, F" +
                    "unc<IQueryable<TPersistence>, IQueryable<TPersistence>> linq, CancellationToken " +
                    "cancellationToken = default);\r\n        Task<int> CountAsync(Expression<Func<TPer" +
                    "sistence, bool>> filterExpression, CancellationToken cancellationToken = default" +
                    ");\r\n        Task<bool> AnyAsync(Expression<Func<TPersistence, bool>> filterExpre" +
                    "ssion, CancellationToken cancellationToken = default);\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
