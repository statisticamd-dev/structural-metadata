using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.RepresentedVariables.Queries.GetRepresentationDetails
{
    public class LevelDto : AbstractBaseDto, IMapFrom<Level>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int LevelNumber { get; set; }
        //public List<NodeDto> Nodes { get; set; }

         public void Mapping(Profile profile)
        {
            //language parameter from request
            //default to english
            string language = "en";
            profile.CreateMap<Level, LevelDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name != null ? s.Name.Text(language) : null))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : null));
                //.ForMember(d => d.Nodes, opt => opt.MapFrom(s => s.Nodes));
        } 
    }
}