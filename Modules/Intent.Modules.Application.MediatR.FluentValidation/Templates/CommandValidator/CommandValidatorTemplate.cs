﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
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
    using Intent.Modules.Application.FluentValidation.Templates;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.FluentValidation\Templates\CommandValidator\CommandValidatorTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class CommandValidatorTemplate : CSharpTemplateBase<Intent.Modelers.Services.CQRS.Api.CommandModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\nusing FluentValidation;\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 16 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.FluentValidation\Templates\CommandValidator\CommandValidatorTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]\r\n    public class ");
            
            #line 19 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.FluentValidation\Templates\CommandValidator\CommandValidatorTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" : AbstractValidator<");
            
            #line 19 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.FluentValidation\Templates\CommandValidator\CommandValidatorTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetCommandModel()));
            
            #line default
            #line hidden
            this.Write(">\r\n    {\r\n        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]\r\n        public ");
            
            #line 22 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.FluentValidation\Templates\CommandValidator\CommandValidatorTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("()\r\n        {\r\n            ConfigureValidationRules();\r\n        }\r\n\r\n        [IntentManaged(Mode.Fully)]\r\n        private void ConfigureValidationRules()\r\n        {\r\n");
            
            #line 30 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.FluentValidation\Templates\CommandValidator\CommandValidatorTemplate.tt"
  foreach(var fieldRule in this.GetValidationRules(Model.Properties)) { 
            
            #line default
            #line hidden
            this.Write("            ");
            
            #line 31 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.FluentValidation\Templates\CommandValidator\CommandValidatorTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(fieldRule));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n");
            
            #line 33 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.FluentValidation\Templates\CommandValidator\CommandValidatorTemplate.tt"
  } 
            
            #line default
            #line hidden
            this.Write("        }\r\n");
            
            #line 35 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.FluentValidation\Templates\CommandValidator\CommandValidatorTemplate.tt"
  foreach(var method in GetCustomValidationMethods()) { 
            
            #line default
            #line hidden
            this.Write("\r\n        ");
            
            #line 37 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.FluentValidation\Templates\CommandValidator\CommandValidatorTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(method));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 38 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.FluentValidation\Templates\CommandValidator\CommandValidatorTemplate.tt"
  } 
            
            #line default
            #line hidden
            this.Write("    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
}
