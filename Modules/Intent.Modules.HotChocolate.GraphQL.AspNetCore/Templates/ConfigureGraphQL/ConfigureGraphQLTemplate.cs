// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.HotChocolate.GraphQL.AspNetCore.Templates.ConfigureGraphQL
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
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.HotChocolate.GraphQL.AspNetCore\Templates\ConfigureGraphQL\ConfigureGraphQLTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class ConfigureGraphQLTemplate : CSharpTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using Microsoft.Extensions.Configuration;\r\nusing Microsoft.Extensions.DependencyI" +
                    "njection;\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 15 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.HotChocolate.GraphQL.AspNetCore\Templates\ConfigureGraphQL\ConfigureGraphQLTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public static class ");
            
            #line 17 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.HotChocolate.GraphQL.AspNetCore\Templates\ConfigureGraphQL\ConfigureGraphQLTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n        public static IServiceCollection ConfigureGraphQL(this IServiceC" +
                    "ollection services, IConfiguration configuration)\r\n        {\r\n            servic" +
                    "es.AddGraphQLServer()");
            
            #line 21 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.HotChocolate.GraphQL.AspNetCore\Templates\ConfigureGraphQL\ConfigureGraphQLTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetGraphQLRegistrations()));
            
            #line default
            #line hidden
            this.Write(";\r\n            return services;\r\n        }\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
