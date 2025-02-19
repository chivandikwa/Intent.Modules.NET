﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Eventing.MassTransit.Templates.MassTransitConfiguration
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
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Eventing.MassTransit\Templates\MassTransitConfiguration\MassTransitConfigurationTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class MassTransitConfigurationTemplate : CSharpTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System.Reflection;\r\nusing MassTransit;\r\nusing Microsoft.Extensions.Configuration;\r\nusing Microsoft.Extensions.DependencyInjection;\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 17 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Eventing.MassTransit\Templates\MassTransitConfiguration\MassTransitConfigurationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public static class ");
            
            #line 19 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Eventing.MassTransit\Templates\MassTransitConfiguration\MassTransitConfigurationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n        public static void AddMassTransitConfiguration(this IServiceCollection services, IConfiguration configuration)\r\n        {\r\n            services.AddMassTransit(x =>\r\n            {\r\n                x.SetKebabCaseEndpointNameFormatter();\r\n\r\n                AddConsumers(x);\r\n                ");
            
            #line 28 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Eventing.MassTransit\Templates\MassTransitConfiguration\MassTransitConfigurationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetMessagingProviderSpecificConfig()));
            
            #line default
            #line hidden
            
            #line 28 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Eventing.MassTransit\Templates\MassTransitConfiguration\MassTransitConfigurationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetAdditionalConfiguration()));
            
            #line default
            #line hidden
            this.Write("\r\n            });\r\n        }\r\n\r\n        private static void AddConsumers(IRegistrationConfigurator cfg)\r\n        {\r\n            ");
            
            #line 34 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Eventing.MassTransit\Templates\MassTransitConfiguration\MassTransitConfigurationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetConsumers()));
            
            #line default
            #line hidden
            this.Write("\r\n        }\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
}
