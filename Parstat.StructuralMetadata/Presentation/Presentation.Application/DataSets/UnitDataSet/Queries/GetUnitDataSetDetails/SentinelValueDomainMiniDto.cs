using System;
using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.DataSets.UnitDataSet.Queries.GetUnitDataSetDetails
{
    public class SentinelValueDomainMiniDto : AbstractBaseDto, IMapFrom<ValueDomain>
    {
        public string Name { get; set; }
        public ValueDomainType Type { get; set; }
        public string Expression { get; set; }
        public DataType DataType { get; set; }
        public string MeasurementUnit { get; set; }
        //public LevelDto NoteSetLevel { get; set; }
        public List<ValueItemMiniDto> ValueSet { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from request
            //default english
            string language = "en";
            profile.CreateMap<ValueDomain, SentinelValueDomainMiniDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name == null ? String.Empty : s.Name.Text(language)))
                .ForMember(d => d.MeasurementUnit, opt => opt.MapFrom(s => s.MeasurementUnit != null ? s.MeasurementUnit.Abbreviation : String.Empty))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(d => d.Expression, opt => opt.MapFrom(s => s.Expression))
                .ForMember(d => d.DataType, opt => opt.MapFrom(s => s.DataType))
                /* .ForMember(d => d.ValueSet, opt => {
                    opt.PreCondition(s => s.Type == ValueDomainType.ENUMERATED);
                    opt.MapFrom(s => s.NodeSet.Nodes);
                    opt.NullSubstitute(new List<ValueItemMiniDto>());
                }) */;
                
                //.ForMember(d => d.NoteSetLevel, opt => opt.MapFrom(s => s.Level != null ? s.Level : null));
        } 
    }
}