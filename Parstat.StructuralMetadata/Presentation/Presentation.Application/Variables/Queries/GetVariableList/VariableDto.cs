using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Converters;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models;
using Presentation.Application.Common.Resolvers;
using Presentation.Domain;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.Variables.Queries.GetVariableList
{
    public class VariableDto : IMapFrom<Variable>
    {
        private readonly ICurrentLanguageService _currentLanguageService;

        public VariableDto() {

        }

        public VariableDto(ICurrentLanguageService currentLanguageService)
        {
            _currentLanguageService = currentLanguageService;
        }
        public long Id { get; set; }
        public string LocalId { get; set; }
        public MultilanguageStringDto Name { get; set; }
        public MultilanguageStringDto Description { get; set; }
        public string Version { get; set; }
        public MultilanguageStringDto Measuers {get; set;}
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Variable, VariableDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.Measuers, opt => opt.MapFrom(s => s.Measures.Name));
        }

    }
}