using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.Variables.Queries.GetVariableDetails
{
    public class SubstantiveValueDomainMiniDto : AbstractBaseDto, IMapFrom<ValueDomain>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from request
            //default english
            string language = "en";
            profile.CreateMap<ValueDomain, SubstantiveValueDomainMiniDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name != null ? s.Name.Text(language) : String.Empty))
               ;
                
                //.ForMember(d => d.NoteSetLevel, opt => opt.MapFrom(s => s.Level != null ? s.Level : null));
        } 
    }
}