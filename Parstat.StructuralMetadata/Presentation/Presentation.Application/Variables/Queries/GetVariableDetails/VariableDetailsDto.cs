using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.Variables.Queries.GetVariableDetails
{
    public class VariableDetailsDto : IMapFrom<Variable>
    {
        public string LocalId { get; set; }
        public MultilanguageStringDto Name { get; set; }
        public MultilanguageStringDto Description { get; set; }
        public string Version { get; set; }
        public UnitTypeDto Measuers {get; set;}
        public virtual List<RepresentedVariableDto> Representations { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Variable, VariableDetailsDto>()
                .ForMember(d => d.Measuers, opt => opt.MapFrom(s => s.Measures))
                .ForMember(d => d.Representations, opt => opt.MapFrom(s => s.Representations))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description));
        }

    }
}