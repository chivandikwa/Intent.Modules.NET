using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modelers.ServiceProxies.Api;
using Intent.Modelers.Services.Api;
using Intent.Modelers.Types.ServiceProxies.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.Registrations;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.TemplateRegistration.FilePerModel", Version = "1.0")]

namespace Intent.Modules.Application.Contracts.Clients.Templates.DtoContract
{
    [IntentManaged(Mode.Merge, Body = Mode.Merge, Signature = Mode.Fully)]
    public class DtoContractTemplateRegistration : FilePerModelTemplateRegistration<ServiceProxyDTOModel>
    {
        private readonly IMetadataManager _metadataManager;

        public DtoContractTemplateRegistration(IMetadataManager metadataManager)
        {
            _metadataManager = metadataManager;
        }

        public override string TemplateId => DtoContractTemplate.TemplateId;

        public override ITemplate CreateTemplateInstance(IOutputTarget outputTarget, ServiceProxyDTOModel model)
        {
            return new DtoContractTemplate(outputTarget, model);
        }

        [IntentManaged(Mode.Merge, Body = Mode.Ignore, Signature = Mode.Fully)]
        public override IEnumerable<ServiceProxyDTOModel> GetModels(IApplication application)
        {
            return _metadataManager.ServiceProxies(application).GetProxyMappedServiceDTOModels();
        }
    }
}