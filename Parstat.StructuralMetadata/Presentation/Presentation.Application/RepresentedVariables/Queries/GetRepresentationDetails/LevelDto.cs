using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.RepresentedVariables.Queries.GetRepresentationDetails
{
    public class LevelDto : IMapFrom<Level>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LevelNumber { get; set; }
        public List<NodeDto> Nodes { get; set; }

         public void Mapping(Profile profile)
        {
            //language parameter from request
            //default to english
            string language = "en";
            profile.CreateMap<Level, LevelDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name.Text(language)))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description.Text(language)))
                .ForMember(d => d.Nodes, opt => opt.MapFrom(s => s.Nodes));
        } 
    }
}