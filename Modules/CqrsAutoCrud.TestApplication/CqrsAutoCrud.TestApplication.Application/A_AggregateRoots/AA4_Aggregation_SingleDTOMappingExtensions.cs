using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using AutoMapper;
using CqrsAutoCrud.TestApplication.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.AutoMapper.MappingExtensions", Version = "1.0")]

namespace CqrsAutoCrud.TestApplication.Application.A_AggregateRoots
{
    public static class AA4_Aggregation_SingleDTOMappingExtensions
    {
        public static AA4_Aggregation_SingleDTO MapToAA4_Aggregation_SingleDTO(this IAA4_Aggregation_Single projectFrom, IMapper mapper)
        {
            return mapper.Map<AA4_Aggregation_SingleDTO>(projectFrom);
        }

        public static List<AA4_Aggregation_SingleDTO> MapToAA4_Aggregation_SingleDTOList(this IEnumerable<IAA4_Aggregation_Single> projectFrom, IMapper mapper)
        {
            return projectFrom.Select(x => x.MapToAA4_Aggregation_SingleDTO(mapper)).ToList();
        }
    }
}