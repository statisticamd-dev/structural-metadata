using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.Variables.Queries.GetVariableList
{
    public class VariableDto : IMapFrom<Variable>
    {
        public long Id { get; set; }
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string Measuers {get; set;}
        public virtual List<RepresentedVariableDto> Representations { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Variable, VariableDto>()
                .ForMember(d => d.Measuers, opt => opt.MapFrom(s => s.Measures.Name))
                .ForMember(d => d.Representations, opt => opt.MapFrom(s => s.Representations));
        }

    }
}