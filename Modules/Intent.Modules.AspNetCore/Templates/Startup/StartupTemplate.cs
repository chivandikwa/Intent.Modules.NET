﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.AspNetCore.Templates.Startup
{
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
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AspNetCore\Templates\Startup\StartupTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class StartupTemplate : CSharpTemplateBase<object, Intent.Modules.AspNetCore.Templates.Startup.StartupDecorator>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(" \r\n");
            this.Write(" \r\nusing System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Threading.Tasks;\r\nusing Microsoft.AspNetCore.Builder;\r\nusing Microsoft.AspNetCore.Hosting;\r\nusing Microsoft.Extensions.Configuration;\r\nusing Microsoft.Extensions.DependencyInjection;\r\nusing Microsoft.Extensions.Logging;\r\nusing Microsoft.Extensions.Options;\r\n");
            
            #line 22 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AspNetCore\Templates\Startup\StartupTemplate.tt"
  if (!IsNetCore2App()) { 
            
            #line default
            #line hidden
            this.Write("using Microsoft.Extensions.Hosting;\r\n");
            
            #line 24 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AspNetCore\Templates\Startup\StartupTemplate.tt"
  } 
            
            #line default
            #line hidden
            this.Write("\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 28 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AspNetCore\Templates\Startup\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    [IntentManaged(Mode.Merge)]\r\n    public class ");
            
            #line 31 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AspNetCore\Templates\Startup\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n        public ");
            
            #line 33 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AspNetCore\Templates\Startup\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("(IConfiguration configuration)\r\n        {\r\n            Configuration = configuration;\r\n        }\r\n\r\n        public IConfiguration Configuration { get; }\r\n\r\n        public void ConfigureServices(IServiceCollection services)\r\n        {\r\n");
            
            #line 42 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AspNetCore\Templates\Startup\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetServiceConfigurations("            ")));
            
            #line default
            #line hidden
            
            #line 42 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AspNetCore\Templates\Startup\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Registrations()));
            
            #line default
            #line hidden
            this.Write("\r\n        }\r\n\r\n        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.\r\n        public void Configure(IApplicationBuilder app, ");
            
            #line 46 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AspNetCore\Templates\Startup\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture((IsNetCore2App() ? "IHostingEnvironment" : "IWebHostEnvironment")));
            
            #line default
            #line hidden
            this.Write(" env)\r\n        {\r\n            if (env.IsDevelopment())\r\n            {\r\n                app.UseDeveloperExceptionPage();\r\n            }\r\n");
            
            #line 52 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AspNetCore\Templates\Startup\StartupTemplate.tt"
  if (IsNetCore2App()) { 
            
            #line default
            #line hidden
            this.Write("            else\r\n            {\r\n                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.\r\n                app.UseHsts();\r\n            }\r\n");
            
            #line 58 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AspNetCore\Templates\Startup\StartupTemplate.tt"
  } 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 60 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AspNetCore\Templates\Startup\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetApplicationConfigurations("            ")));
            
            #line default
            #line hidden
            this.Write("\r\n        }");
            
            #line 61 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AspNetCore\Templates\Startup\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetDecoratorsOutput(x => x.Methods())));
            
            #line default
            #line hidden
            this.Write("\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
}
