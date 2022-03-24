// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.IdentityServer4.SecureTokenServer.Templates.IdentityServerConfiguration
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
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.IdentityServer4.SecureTokenServer\Templates\IdentityServerConfiguration\IdentityServerConfigurationTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class IdentityServerConfigurationTemplate : CSharpTemplateBase<object, Intent.Modules.IdentityServer4.SecureTokenServer.Templates.IdentityServerConfiguration.IdentityConfigurationDecorator>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing Microsoft.Extensions.Conf" +
                    "iguration;\r\nusing Microsoft.Extensions.DependencyInjection;\r\n\r\n[assembly: Defaul" +
                    "tIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 17 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.IdentityServer4.SecureTokenServer\Templates\IdentityServerConfiguration\IdentityServerConfigurationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public static class ");
            
            #line 19 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.IdentityServer4.SecureTokenServer\Templates\IdentityServerConfiguration\IdentityServerConfigurationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n        public static IServiceCollection ConfigureIdentityServer(this IS" +
                    "erviceCollection services, IConfiguration configuration)\r\n        {\r\n           " +
                    " var idServerBuilder = services.AddIdentityServer();\r\n            ");
            
            #line 24 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.IdentityServer4.SecureTokenServer\Templates\IdentityServerConfiguration\IdentityServerConfigurationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetServiceConfigurations("            ")));
            
            #line default
            #line hidden
            this.Write(@"
            idServerBuilder.AddInMemoryClients(configuration.GetSection(""IdentityServer:Clients""))
                .AddInMemoryApiResources(configuration.GetSection(""IdentityServer:ApiResources""))
                .AddInMemoryApiScopes(configuration.GetSection(""IdentityServer:ApiScopes""))
                .AddInMemoryIdentityResources(configuration.GetSection(""IdentityServer:IdentityResources""));

            return services;
        }
        ");
            
            #line 32 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.IdentityServer4.SecureTokenServer\Templates\IdentityServerConfiguration\IdentityServerConfigurationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetDecoratorsOutput(x => x.Methods())));
            
            #line default
            #line hidden
            this.Write("\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
