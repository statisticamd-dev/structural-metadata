using System;
using AutoMapper;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Mappings;
using Presentation.Common.Domain.StructuralMetadata.Enums;
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
        public void Mapping(Profile profile)
        {
            string language = "en";
            profile.CreateMap<Variable, VariableDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name.Text(language)))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description.Text(language)))
                .ForMember(d => d.Measuers, opt => opt.MapFrom(s => s.Measures.Name.Text(language)));
        }

    }
}