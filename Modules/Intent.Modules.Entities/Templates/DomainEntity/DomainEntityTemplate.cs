﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Entities.Templates.DomainEntity
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
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\DomainEntity\DomainEntityTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class DomainEntityTemplate : CSharpTemplateBase<Intent.Modelers.Domain.Api.ClassModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\n");
            
            #line 15 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\DomainEntity\DomainEntityTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DependencyUsings));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 19 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\DomainEntity\DomainEntityTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    [IntentManaged(Mode.Merge)]\r\n    [DefaultIntentManaged(Mode.Merge, Signature = Mode.Fully, Body = Mode.Ignore, Targets = Targets.Methods, AccessModifiers = AccessModifiers.Public)]\r\n    public partial class ");
            
            #line 23 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\DomainEntity\DomainEntityTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n");
            
            #line 25 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\DomainEntity\DomainEntityTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Constructors(Model)));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 26 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\DomainEntity\DomainEntityTemplate.tt"
 	foreach (var operation in Model.Operations)
    {
        if (!operation.IsAbstract)
        {
            
            #line default
            #line hidden
            this.Write("        public ");
            
            #line 30 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\DomainEntity\DomainEntityTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EmitOperationReturnType(operation)));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 30 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\DomainEntity\DomainEntityTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operation.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 30 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\DomainEntity\DomainEntityTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetParametersDefinition(operation)));
            
            #line default
            #line hidden
            this.Write(")\r\n        {\r\n            throw new NotImplementedException(\"Replace with your implementation...\");\r\n        }\r\n");
            
            #line 34 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\DomainEntity\DomainEntityTemplate.tt"
		}
        else
        { 
            
            #line default
            #line hidden
            this.Write("        public abstract ");
            
            #line 37 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\DomainEntity\DomainEntityTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EmitOperationReturnType(operation)));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 37 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\DomainEntity\DomainEntityTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operation.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 37 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\DomainEntity\DomainEntityTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetParametersDefinition(operation)));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 38 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\DomainEntity\DomainEntityTemplate.tt"
		}
    }

            
            #line default
            #line hidden
            this.Write("    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
}
