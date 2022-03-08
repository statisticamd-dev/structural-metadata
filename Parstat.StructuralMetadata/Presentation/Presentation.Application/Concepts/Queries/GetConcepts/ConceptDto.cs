using System;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.Concepts.Queries.GetConcepts
{
    public class ConceptDto : AbstractBaseDto, IMapFrom<Concept>
    {
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from  request
            //default english
            string language = "en";
            profile.CreateMap<Concept, ConceptDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name == null ? String.Empty : s.Name.Text(language)))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : String.Empty));
        }
    }
}
