using System;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.DataStructures.Common.GetDataStructureDetails
{
    public class RepresentationTinyDto : AbstractBaseDto, IMapFrom<RepresentedVariable>
    {
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string VariableName { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from  request
            //default english
            string language = "en";
            profile.CreateMap<RepresentedVariable, RepresentationTinyDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name != null ? s.Name.Text(language) : String.Empty))
                .ForMember(d => d.VariableName, opt => opt.MapFrom(s => s.Variable.Name != null ? s.Variable.Name.Text(language) : String.Empty));
        }
        
    }
}