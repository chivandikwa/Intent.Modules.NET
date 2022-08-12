using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modelers.Domain.Api;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiPackageExtensionModel", Version = "1.0")]

namespace Intent.EntityFrameworkCore.Api
{
    [IntentManaged(Mode.Merge)]
    public class PackageExtensionModel : DomainPackageModel
    {
        [IntentManaged(Mode.Ignore)]
        public PackageExtensionModel(IPackage package) : base(package)
        {
        }

    }
}