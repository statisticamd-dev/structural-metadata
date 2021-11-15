using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.RepresentedVariables.Queries.GetRepresentationDetails
{
    public class ValueSetDto : AbstractBaseDto, IMapFrom<NodeSet>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public NodeSetType ValueSetType { get; set; }

        public List<ValueItemDto> ValueItems { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from request
            //default english
            string language = "en";
            profile.CreateMap<NodeSet, ValueSetDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name != null ? s.Name.Text(language) : null))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : null))
                .ForMember(d => d.ValueSetType, opt => opt.MapFrom(s => s.NodeSetType))
                //.ForMember(d => d.NoteSetLevel, opt => opt.MapFrom(s => s.Level != null ? s.Level : null));
                .ForMember(d => d.ValueItems, opt => opt.MapFrom(s => s.Nodes));
        } 
    }
}