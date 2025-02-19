// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.EntityFrameworkCore.Templates.DbContextInterface
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
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContextInterface\DbContextInterfaceTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class DbContextInterfaceTemplate : CSharpTemplateBase<IList<Intent.Modelers.Domain.Api.ClassModel>>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(" \r\nusing System.Threading;\r\nusing System.Threading.Tasks;\r\nusing Microsoft.Entity" +
                    "FrameworkCore;\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 18 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContextInterface\DbContextInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public interface ");
            
            #line 20 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContextInterface\DbContextInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n");
            
            #line 22 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContextInterface\DbContextInterfaceTemplate.tt"

foreach (var typeConfiguration in _entityTypeConfigurations)
{

            
            #line default
            #line hidden
            this.Write("        DbSet<");
            
            #line 26 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContextInterface\DbContextInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetEntityName(typeConfiguration.Template.Model)));
            
            #line default
            #line hidden
            this.Write("> ");
            
            #line 26 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContextInterface\DbContextInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetEntityName(typeConfiguration.Template.Model).Pluralize()));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n");
            
            #line 27 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContextInterface\DbContextInterfaceTemplate.tt"

}

            
            #line default
            #line hidden
            this.Write("        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(" +
                    "CancellationToken));\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
