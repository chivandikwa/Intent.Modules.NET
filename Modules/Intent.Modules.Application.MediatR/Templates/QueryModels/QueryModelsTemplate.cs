// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Application.MediatR.Templates.QueryModels
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.CSharp.Templates;
    using Intent.Templates;
    using Intent.Metadata.Models;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR\Templates\QueryModels\QueryModelsTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class QueryModelsTemplate : CSharpTemplateBase<Intent.Modelers.Services.CQRS.Api.QueryModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using MediatR;\r\nusing System;\r\nusing System.Collections.Generic;\r\n\r\n[assembly: De" +
                    "faultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 16 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR\Templates\QueryModels\QueryModelsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    ");
            
            #line 18 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR\Templates\QueryModels\QueryModelsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetQueryAttributes()));
            
            #line default
            #line hidden
            this.Write("public class ");
            
            #line 18 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR\Templates\QueryModels\QueryModelsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" : ");
            
            #line 18 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR\Templates\QueryModels\QueryModelsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetRequestInterface()));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n");
            
            #line 20 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR\Templates\QueryModels\QueryModelsTemplate.tt"
  foreach(var property in Model.Properties) { 
            
            #line default
            #line hidden
            this.Write("        public ");
            
            #line 21 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR\Templates\QueryModels\QueryModelsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetTypeName(property)));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 21 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR\Templates\QueryModels\QueryModelsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n\r\n");
            
            #line 23 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR\Templates\QueryModels\QueryModelsTemplate.tt"
  } 
            
            #line default
            #line hidden
            this.Write("    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
