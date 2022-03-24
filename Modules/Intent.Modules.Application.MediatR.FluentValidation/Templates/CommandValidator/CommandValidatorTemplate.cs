// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Application.MediatR.FluentValidation.Templates.CommandValidator
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
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.FluentValidation\Templates\CommandValidator\CommandValidatorTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class CommandValidatorTemplate : CSharpTemplateBase<Intent.Modelers.Services.CQRS.Api.CommandModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\nusing FluentValidation;\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fu" +
                    "lly)]\r\n\r\nnamespace ");
            
            #line 15 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.FluentValidation\Templates\CommandValidator\CommandValidatorTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]\r\n    public class ");
            
            #line 18 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.FluentValidation\Templates\CommandValidator\CommandValidatorTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" : AbstractValidator<");
            
            #line 18 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.FluentValidation\Templates\CommandValidator\CommandValidatorTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetCommandModel()));
            
            #line default
            #line hidden
            this.Write(">\r\n    {\r\n        [IntentManaged(Mode.Fully)]\r\n        public ");
            
            #line 21 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.FluentValidation\Templates\CommandValidator\CommandValidatorTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("()\r\n        {\r\n");
            
            #line 23 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.FluentValidation\Templates\CommandValidator\CommandValidatorTemplate.tt"
  foreach(var fieldRule in this.GetValidationRules(Model.Properties)) { 
            
            #line default
            #line hidden
            this.Write("            ");
            
            #line 24 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.FluentValidation\Templates\CommandValidator\CommandValidatorTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(fieldRule));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n");
            
            #line 26 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.FluentValidation\Templates\CommandValidator\CommandValidatorTemplate.tt"
  } 
            
            #line default
            #line hidden
            this.Write("        }\r\n");
            
            #line 28 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.FluentValidation\Templates\CommandValidator\CommandValidatorTemplate.tt"
  foreach(var method in GetCustomValidationMethods()) { 
            
            #line default
            #line hidden
            this.Write("\r\n        ");
            
            #line 30 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.FluentValidation\Templates\CommandValidator\CommandValidatorTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(method));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 31 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.FluentValidation\Templates\CommandValidator\CommandValidatorTemplate.tt"
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
