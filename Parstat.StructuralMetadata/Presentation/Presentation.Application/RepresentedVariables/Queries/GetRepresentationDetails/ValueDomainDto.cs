using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.RepresentedVariables.Queries.GetRepresentationDetails
{
    public class ValueDomainDto : AbstractBaseDto, IMapFrom<ValueDomain>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ValueDomainType Type { get; set; }
        public string Expression { get; set; }
        public DataType DataType { get; set; }
        //public LevelDto NoteSetLevel { get; set; }
        public List<ValueItemDto> ValueSet { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from request
            //default english
            string language = "en";
            profile.CreateMap<ValueDomain, ValueDomainDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name != null ? s.Name.Text(language) : string.Empty))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : string.Empty))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(d => d.Expression, opt => opt.MapFrom(s => s.Expression))
                .ForMember(d => d.DataType, opt => opt.MapFrom(s => s.DataType))
                .ForMember(d => d.ValueSet, opt => opt.MapFrom(s => s.NodeSet.Nodes));
                //.ForMember(d => d.NoteSetLevel, opt => opt.MapFrom(s => s.Level != null ? s.Level : null));
        } 
    }
}