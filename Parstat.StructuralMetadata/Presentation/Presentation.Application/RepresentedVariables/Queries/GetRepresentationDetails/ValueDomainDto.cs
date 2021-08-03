using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.RepresentedVariables.Queries.GetRepresentationDetails
{
    public class ValueDomainDto : IMapFrom<ValueDomain>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ValueDomainType Type { get; set; }
        public string Expression { get; set; }
        public DataType DataType { get; set; }
        public LevelDto NoteSetLevel { get; set; }
        public NodeSetDto NodeSet { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ValueDomain, ValueDomainDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(d => d.Expression, opt => opt.MapFrom(s => s.Expression))
                .ForMember(d => d.DataType, opt => opt.MapFrom(s => s.DataType))
                .ForMember(d => d.NoteSetLevel, opt => opt.MapFrom(s => s.Level))
                .ForMember(d => d.NodeSet, opt => opt.MapFrom(s => s.NodeSet));
        } 
    }
}