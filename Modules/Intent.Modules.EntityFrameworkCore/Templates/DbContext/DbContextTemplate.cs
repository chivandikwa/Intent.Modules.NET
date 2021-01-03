﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.EntityFrameworkCore.Templates.DbContext
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
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContext\DbContextTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class DbContextTemplate : CSharpTemplateBase<IList<ClassModel>, DbContextDecoratorBase>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System.Linq;\r\nusing System.Threading;\r\nusing System.Threading.Tasks;\r\nusing" +
                    " Microsoft.EntityFrameworkCore;\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r" +
                    "\nnamespace ");
            
            #line 21 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class ");
            
            #line 23 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" : ");
            
            #line 23 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetBaseTypes()));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n        ");
            
            #line 25 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetPrivateFields()));
            
            #line default
            #line hidden
            this.Write("\r\n        public ");
            
            #line 26 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("(DbContextOptions options");
            
            #line 26 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetConstructorParameters()));
            
            #line default
            #line hidden
            this.Write(") : base(options)\r\n        {");
            
            #line 27 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetConstructorInitializations()));
            
            #line default
            #line hidden
            this.Write("\r\n        }\r\n\r\n");
            
            #line 30 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContext\DbContextTemplate.tt"

foreach (var model in Model)
{

            
            #line default
            #line hidden
            this.Write("        public DbSet<");
            
            #line 34 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetEntityName(model)));
            
            #line default
            #line hidden
            this.Write("> ");
            
            #line 34 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetEntityName(model).ToPluralName()));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n");
            
            #line 35 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContext\DbContextTemplate.tt"

}

            
            #line default
            #line hidden
            this.Write("\r\n        public override async Task<int> SaveChangesAsync(CancellationToken canc" +
                    "ellationToken = new CancellationToken())\r\n        {\r\n            ");
            
            #line 41 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetDecoratorsOutput(x => x.BeforeCallToSaveChangesAsync())));
            
            #line default
            #line hidden
            this.Write("\r\n            var result = await base.SaveChangesAsync(cancellationToken);\r\n     " +
                    "       ");
            
            #line 43 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetDecoratorsOutput(x => x.AfterCallToSaveChangesAsync())));
            
            #line default
            #line hidden
            this.Write("\r\n            return result;\r\n        }\r\n\r\n        protected override void OnMode" +
                    "lCreating(ModelBuilder modelBuilder)\r\n        {\r\n            base.OnModelCreatin" +
                    "g(modelBuilder);\r\n\r\n            ConfigureModel(modelBuilder);\r\n\r\n");
            
            #line 53 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContext\DbContextTemplate.tt"

foreach (var model in Model)
{

            
            #line default
            #line hidden
            this.Write("            modelBuilder.ApplyConfiguration(new ");
            
            #line 57 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetMappingClassName(model)));
            
            #line default
            #line hidden
            this.Write("());\r\n");
            
            #line 58 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContext\DbContextTemplate.tt"

}

            
            #line default
            #line hidden
            this.Write("        }\r\n\r\n        [IntentManaged(Mode.Ignore)]\r\n        private void Configure" +
                    "Model(ModelBuilder modelBuilder)\r\n        {\r\n            // Customize Default Sc" +
                    "hema\r\n            // modelBuilder.HasDefaultSchema(\"");
            
            #line 67 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Project.Application.Name));
            
            #line default
            #line hidden
            this.Write(@""");
            
            // Seed data
            // https://rehansaeed.com/migrating-to-entity-framework-core-seed-data/
            /* Eg.

            modelBuilder.Entity<Car>().HasData(
                new Car() { CarId = 1, Make = ""Ferrari"", Model = ""F40"" },
                new Car() { CarId = 2, Make = ""Ferrari"", Model = ""F50"" },
                new Car() { CarId = 3, Make = ""Labourghini"", Model = ""Countach"" });
            */
        }");
            
            #line 78 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbContext\DbContextTemplate.tt"
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
