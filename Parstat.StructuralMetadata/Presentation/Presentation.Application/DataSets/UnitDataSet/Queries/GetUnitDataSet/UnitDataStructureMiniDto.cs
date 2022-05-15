using System;
using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;

namespace Presentation.Application.DataSets.UnitDataSet.Queries.GetUnitDataSet
{
    public class UnitDataStructureMiniDto : AbstractIdentifiableArtefactDto, IMapFrom<DataStructure>
    {
        public List<LogicalRecordMiniDto> LogicalRecords { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from  request
            //default english
            string language = "en";
            profile.CreateMap<DataStructure, UnitDataStructureMiniDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name == null ? String.Empty : s.Name.Text(language)))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : String.Empty))
                .ForMember(d => d.VersionRationale, opt => opt.MapFrom(s => s.VersionRationale != null ? s.VersionRationale.Text(language) : String.Empty))
                .ForMember(d => d.LogicalRecords, opt => {
                    opt.PreCondition(s => s.LogicalRecords.Count > 0);
                    opt.MapFrom(s => s.LogicalRecords);
                    opt.NullSubstitute(new List<LogicalRecordMiniDto>());
                } );
        
        }
    }
}