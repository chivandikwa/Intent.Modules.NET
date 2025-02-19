using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modelers.Domain.Api;
using Intent.Modelers.Services.Api;
using Intent.Modules.Application.AutoMapper.Templates.MapFromInterface;
using Intent.Modules.Application.Dtos.Templates.DtoModel;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Templates;
using Intent.Modules.Constants;
using Intent.RoslynWeaver.Attributes;
using GeneralizationModel = Intent.Modelers.Domain.Api.GeneralizationModel;
using OperationModel = Intent.Modelers.Domain.Api.OperationModel;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.TemplateDecorator", Version = "1.0")]

namespace Intent.Modules.Application.Dtos.AutoMapper.Decorators
{
    [IntentManaged(Mode.Merge)]
    public class AutoMapperDtoDecorator : DtoModelDecorator, IDeclareUsings
    {
        [IntentManaged(Mode.Fully)] public const string DecoratorId = "Intent.Application.Dtos.AutoMapper.AutoMapperDtoDecorator";

        [IntentManaged(Mode.Fully)] private readonly DtoModelTemplate _template;
        [IntentManaged(Mode.Fully)] private readonly IApplication _application;

        [IntentManaged(Mode.Merge, Body = Mode.Fully)]
        public AutoMapperDtoDecorator(DtoModelTemplate template, IApplication application)
        {
            _template = template;
            _application = application;
        }

        private ICSharpFileBuilderTemplate _entityTemplate;

        public ICSharpFileBuilderTemplate EntityTemplate => _entityTemplate ??=
            _template.TryGetTemplate(TemplateFulfillingRoles.Domain.Entity.Primary, _template.Model.Mapping.ElementId, out _entityTemplate) 
                ? _entityTemplate 
                : _template.TryGetTemplate(TemplateFulfillingRoles.Domain.ValueObject, _template.Model.Mapping.ElementId, out _entityTemplate) 
                    ? _entityTemplate 
                    : null;

        public IEnumerable<string> DeclareUsings()
        {
            if (!_template.Model.HasMapFromDomainMapping())
            {
                yield break;
            }

            yield return "AutoMapper";
        }

        public override IEnumerable<string> BaseInterfaces()
        {
            if (!_template.Model.HasMapFromDomainMapping())
            {
                return base.BaseInterfaces();
            }

            return new[] { $"{_template.GetTypeName(MapFromInterfaceTemplate.TemplateId)}<{EntityTemplate.ClassName}>" };
        }

        public override string ExitClass()
        {
            if (!_template.Model.HasMapFromDomainMapping())
            {
                return base.ExitClass();
            }

            var memberMappings = new List<string>();
            foreach (var field in _template.Model.Fields.Where(x => x.Mapping != null))
            {
                var shouldCast = _template.GetTypeInfo(field.TypeReference).IsPrimitive
                                 && field.Mapping.Element?.TypeReference != null
                                 && _template.GetFullyQualifiedTypeName(field.TypeReference) != EntityTemplate.GetFullyQualifiedTypeName(field.Mapping.Element.TypeReference);
                var mappingExpression = GetMappingExpression(field);
                if ("src." + field.Name.ToPascalCase() != mappingExpression || shouldCast)
                {
                    memberMappings.Add($@"
                .ForMember(d => d.{field.Name.ToPascalCase()}, opt => opt.MapFrom(src => {(shouldCast ? $"({_template.GetTypeName(field)})" : string.Empty)}{mappingExpression}))");
                }
                else if (field.TypeReference.IsCollection && field.TypeReference.Element.Name != field.Mapping.Element?.TypeReference?.Element.Name)
                {
                    memberMappings.Add($@"
                .ForMember(d => d.{field.Name.ToPascalCase()}, opt => opt.MapFrom(src => {mappingExpression}))");
                }
            }

            return $@"
        public void Mapping(Profile profile)
        {{
            profile.CreateMap<{_template.GetTypeName(EntityTemplate)}, {_template.ClassName}>(){string.Join(string.Empty, memberMappings)};
        }}";
        }

        private string GetMappingExpression(DTOFieldModel field)
        {
            var path = field.Mapping.Path;

            if (path.Count != 1
                || !path.First().Element.IsAssociationEndModel()
                || !_template.GetTypeInfo(field.TypeReference).IsPrimitive)
            {
                return $"src.{GetPath(path)}";
            }

            var association = path.First().Element.AsAssociationEndModel().Association;
            var result = (association.SourceEnd.Multiplicity, association.TargetEnd.Multiplicity) switch
            {
                (Multiplicity.ZeroToOne, Multiplicity.ZeroToOne) => GetPK(path),
                (Multiplicity.ZeroToOne, Multiplicity.One) => GetPK(path),
                (Multiplicity.ZeroToOne, Multiplicity.Many) => GetMultiplePK(path),
                (Multiplicity.One, Multiplicity.ZeroToOne) => GetPK(path),
                (Multiplicity.One, Multiplicity.One) => GetPK(path),
                (Multiplicity.One, Multiplicity.Many) => GetMultiplePK(path),
                (Multiplicity.Many, Multiplicity.ZeroToOne) => GetLocalFK(path),
                (Multiplicity.Many, Multiplicity.One) => GetLocalFK(path),
                (Multiplicity.Many, Multiplicity.Many) => GetMultiplePK(path),
                _ => throw new InvalidOperationException($"Problem resolving association {association.SourceEnd.Multiplicity} -> {association.TargetEnd.Multiplicity}")
            };

            return result;
        }

        private string GetPK(IList<IElementMappingPathTarget> path)
        {
            return $"src.{GetPath(path)}.Id";
        }

        private string GetMultiplePK(IList<IElementMappingPathTarget> path)
        {
            _template.AddUsing("System.Linq");
            return $"src.{GetPath(path)}.Select(x => x.Id).ToArray()";
        }

        private string GetLocalFK(IList<IElementMappingPathTarget> path)
        {
            var association = path.First().Element.AsAssociationEndModel();
            return $"src.{association.Name.ToPascalCase()}Id";
        }

        private string GetPath(IEnumerable<IElementMappingPathTarget> path)
        {
            return string.Join(".", path
                .Where(x => x.Specialization != GeneralizationModel.SpecializationType)
                .Select(x => x.Specialization == OperationModel.SpecializationType ? $"{x.Name.ToPascalCase()}()" : x.Name.ToPascalCase()));
        }
    }
}