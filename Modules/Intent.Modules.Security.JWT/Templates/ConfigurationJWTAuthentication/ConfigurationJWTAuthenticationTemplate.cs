// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Security.JWT.Templates.ConfigurationJWTAuthentication
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.CSharp.Templates;
    using Intent.Templates;
    using Intent.Metadata.Models;
    using Intent.Modules.Application.Identity.Templates;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Security.JWT\Templates\ConfigurationJWTAuthentication\ConfigurationJWTAuthenticationTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class ConfigurationJWTAuthenticationTemplate : CSharpTemplateBase<object, Intent.Modules.Security.JWT.Templates.ConfigurationJWTAuthentication.JWTAuthenticationDecorator>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing Microsoft.Extensions.Conf" +
                    "iguration;\r\nusing Microsoft.Extensions.DependencyInjection;\r\nusing Microsoft.Asp" +
                    "NetCore.Authorization;\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamesp" +
                    "ace ");
            
            #line 19 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Security.JWT\Templates\ConfigurationJWTAuthentication\ConfigurationJWTAuthenticationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public static class ");
            
            #line 21 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Security.JWT\Templates\ConfigurationJWTAuthentication\ConfigurationJWTAuthenticationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(@"
    {
        // Use '[IntentManaged(Mode.Ignore)]' on this method should you want to deviate from the standard JWT token approach
        public static IServiceCollection ConfigureJWTSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
            services.AddScoped<");
            
            #line 27 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Security.JWT\Templates\ConfigurationJWTAuthentication\ConfigurationJWTAuthenticationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.GetCurrentUserServiceInterfaceName()));
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 27 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Security.JWT\Templates\ConfigurationJWTAuthentication\ConfigurationJWTAuthenticationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.GetCurrentUserServiceName()));
            
            #line default
            #line hidden
            this.Write(">();\r\n            services.AddHttpContextAccessor();\r\n            ");
            
            #line 29 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Security.JWT\Templates\ConfigurationJWTAuthentication\ConfigurationJWTAuthenticationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(base.GetDecoratorsOutput(p => p.GetConfigurationCode())));
            
            #line default
            #line hidden
            this.Write(@"
            services.AddAuthorization(ConfigureAuthorization);

            return services;
        }

        [IntentManaged(Mode.Ignore)]
        private static void ConfigureAuthorization(AuthorizationOptions options)
        {
            //Configure policies and other authorization options here. For example:
            //options.AddPolicy(""EmployeeOnly"", policy => policy.RequireClaim(""role"", ""employee""));
            //options.AddPolicy(""AdminOnly"", policy => policy.RequireClaim(""role"", ""admin""));
        }
    }
}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
