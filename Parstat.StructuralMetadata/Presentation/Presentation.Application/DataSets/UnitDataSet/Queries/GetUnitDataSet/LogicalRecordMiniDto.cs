using System;
using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;

namespace Presentation.Application.DataSets.UnitDataSet.Queries.GetUnitDataSet
{
    public class LogicalRecordMiniDto : AbstractIdentifiableArtefactDto, IMapFrom<LogicalRecord>
    {
        public string UnitType { get; set; }
        public string ParentRecord { get; set; }
        public List<UnitComponentMiniDto> Components { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from  request
            //default english
            string language = "en";
            profile.CreateMap<LogicalRecord, LogicalRecordMiniDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name == null ? String.Empty : s.Name.Text(language)))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : String.Empty))
                .ForMember(d => d.VersionRationale, opt => opt.MapFrom(s => s.VersionRationale != null ? s.VersionRationale.Text(language) : String.Empty))
                .ForMember(d => d.UnitType, opt => opt.MapFrom(s => s.UnitType != null && s.UnitType.Name != null ? s.UnitType.Name.Text(language) : String.Empty))
                .ForMember(d => d.ParentRecord, opt => opt.MapFrom(s => s.Parent != null ? s.Parent.LocalId : String.Empty))
                .ForMember(d => d.Components, opt => {
                    opt.PreCondition(s => s.Components.Count > 0);
                    opt.MapFrom(s => s.Components);
                    opt.NullSubstitute( new List<UnitComponentMiniDto>());
                });
        }
    }
}