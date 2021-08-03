using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.RepresentedVariables.Queries.GetRepresentationDetails
{
    public class NodeSetDto : IMapFrom<NodeSet>
    {
        
        public long Id { get; set; }
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string Definition { get; set; }
        public NodeSetType NodeSetType { get; set; }
        public List<NodeDto> Nodes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NodeSet, NodeSetDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.LocalId, opt => opt.MapFrom(s => s.LocalId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.Version, opt => opt.MapFrom(s => s.Version))
                .ForMember(d => d.Definition, opt => opt.MapFrom(s => s.Definition))
                .ForMember(d => d.NodeSetType, opt => opt.MapFrom(s => s.NodeSetType))
                .ForMember(d => d.Nodes, opt => opt.MapFrom(s => s.Nodes));
        } 
    }
}