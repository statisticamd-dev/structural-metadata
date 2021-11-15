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
    public class NodeSetDto : AbstractConceptDto, IMapFrom<NodeSet>
    {
        
        public NodeSetType NodeSetType { get; set; }
        //public List<NodeDto> Nodes { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from request
            //default english
            string language = "en";
            profile.CreateMap<NodeSet, NodeSetDto>()
               .ForMember(ns => ns.Name, opt => opt.MapFrom(s => s.Name != null ? s.Name.Text(language) : null))
                .ForMember(ns => ns.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : null))
                .ForMember(ns => ns.Definition, opt => opt.MapFrom(s => s.Definition != null ? s.Definition.Text(language) : null))
                .ForMember(ns => ns.VersionRationale, opt => opt.MapFrom(s => s.VersionRationale.Text(language)))
                .ForMember(ns => ns.Link, opt => opt.MapFrom(s => s.Link != null ? s.Link.Text(language) : null));
                //.ForMember(d => d.NodeSetType, opt => opt.MapFrom(s => s.NodeSetType));
                //.ForMember(d => d.Nodes, opt => opt.MapFrom(s => s.Nodes));
        } 
    }
}