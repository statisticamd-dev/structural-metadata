using System;
using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.Variables.Queries.GetVariableDetails
{
    public class VariableDetailsDto : AbstractIdentifiableArtefactDto, IMapFrom<Variable>
    {
        public UnitTypeMiniDto Measuers {get; set;}
        public virtual List<RepresentedVariableMiniDto> Representations { get; set; }
        public void Mapping(Profile profile)
        {
            //language passed as parameter on request
            //default to english
            string language = "en";
            profile.CreateMap<Variable, VariableDetailsDto>()
                .ForMember(d => d.Measuers, opt => opt.MapFrom(s => s.Measures))
                .ForMember(d => d.Representations, opt => opt.MapFrom(s => s.Representations))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name != null ? s.Name.Text(language) : String.Empty))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : String.Empty))
                .ForMember(d => d.VersionRationale, opt => opt.MapFrom(s => s.VersionRationale != null ?s.VersionRationale.Text(language) : String.Empty)
                );
        }

    }
}