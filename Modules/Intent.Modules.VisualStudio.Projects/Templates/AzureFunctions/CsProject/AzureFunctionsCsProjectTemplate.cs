// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.VisualStudio.Projects.Templates.AzureFunctions.CsProject
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Metadata.Models;
    using Intent.Modules.VisualStudio.Projects.Templates;
    using Intent.Modules.VisualStudio.Projects.Api;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.VisualStudio.Projects\Templates\AzureFunctions\CsProject\AzureFunctionsCsProjectTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class AzureFunctionsCsProjectTemplate : VisualStudioProjectTemplateBase<AzureFunctionsProjectModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\n");
            this.Write("<Project Sdk=\"Microsoft.NET.Sdk\">\r\n\r\n  <PropertyGroup>\r\n    <TargetFramework>");
            
            #line 12 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.VisualStudio.Projects\Templates\AzureFunctions\CsProject\AzureFunctionsCsProjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Join(";", Model.TargetFrameworkVersion())));
            
            #line default
            #line hidden
            this.Write("</TargetFramework>\r\n    <AzureFunctionsVersion>");
            
            #line 13 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.VisualStudio.Projects\Templates\AzureFunctions\CsProject\AzureFunctionsCsProjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.GetAzureFunctionsProjectSettings().AzureFunctionsVersion().Value));
            
            #line default
            #line hidden
            this.Write(@"</AzureFunctionsVersion>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Microsoft.NET.Sdk.Functions"" Version=""4.0.1"" />
  </ItemGroup>

  <ItemGroup>
    <None Update=""host.json"">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
  </ItemGroup>

</Project>
");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
