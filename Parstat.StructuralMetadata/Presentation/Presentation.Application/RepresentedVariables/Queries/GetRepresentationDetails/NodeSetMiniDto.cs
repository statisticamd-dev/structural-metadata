using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.RepresentedVariables.Queries.GetRepresentationDetails
{
    public class NodeSetMiniDto : AbstractBaseDto, IMapFrom<NodeSet>
    {
       // public string Name { get; set; }
        public NodeSetType NodeSetType { get; set; }
        //public List<NodeDto> Nodes { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from request
            //default english
            string language = "en";
            profile.CreateMap<NodeSet, NodeSetMiniDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
               // .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name != null ? s.Name.Text(language) : null))
                .ForMember(d => d.NodeSetType, opt => opt.MapFrom(s => s.NodeSetType));
                //.ForMember(d => d.Nodes, opt => opt.MapFrom(s => s.Nodes));
        } 
    }
}