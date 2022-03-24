﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.EntityFramework.Templates.DbContext
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
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFramework\Templates\DbContext\DbContextTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class DbContextTemplate : CSharpTemplateBase<IEnumerable<ClassModel>>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(" \r\nusing System.Data.Entity;\r\nusing System.Data.Entity.ModelConfiguration.Convent" +
                    "ions;\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 20 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFramework\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class ");
            
            #line 22 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFramework\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" : ");
            
            #line 22 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFramework\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetBaseClass()));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n        public ");
            
            #line 24 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFramework\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("() : base(\"");
            
            #line 24 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFramework\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Project.Application.Name));
            
            #line default
            #line hidden
            this.Write("DB\")\r\n        {\r\n\r\n        } \r\n\r\n        protected override void OnModelCreating(" +
                    "DbModelBuilder modelBuilder)\r\n        {\r\n            base.OnModelCreating(modelB" +
                    "uilder);\r\n\r\n            ConfigureConventions(modelBuilder);\r\n            \r\n");
            
            #line 35 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFramework\Templates\DbContext\DbContextTemplate.tt"
 foreach (var model in Model) {
            
            #line default
            #line hidden
            this.Write("            modelBuilder.Configurations.Add(new ");
            
            #line 36 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFramework\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetMappingName(model)));
            
            #line default
            #line hidden
            this.Write("());\r\n");
            
            #line 37 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFramework\Templates\DbContext\DbContextTemplate.tt"
 }
            
            #line default
            #line hidden
            this.Write(@"        }

		[IntentManaged(Mode.Ignore)]
        private void ConfigureConventions(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

			// Customize Default Schema
			// modelBuilder.HasDefaultSchema(""");
            
            #line 46 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFramework\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Project.Application.Name));
            
            #line default
            #line hidden
            this.Write("\");\r\n        }");
            
            #line 47 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFramework\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetMethods()));
            
            #line default
            #line hidden
            this.Write("\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
