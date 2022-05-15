using System;
using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;

namespace Presentation.Application.DataStructures.UnitDataStructure.Queries.GetDataStructureDetails
{
    public class UnitDataStructureDetailsDto : AbstractIdentifiableArtefactDto, IMapFrom<DataStructure>
    {
        public DataSetType Type { get; set; }
        public List<RecordDto> Records { get; set; }
        public List<UnitComponentsDetailsDto> Components { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from  request
            //default english
            string language = "en";
            profile.CreateMap<DataStructure, UnitDataStructureDetailsDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name != null ? s.Name.Text(language) : String.Empty))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : String.Empty))
                .ForMember(d => d.VersionRationale, opt => opt.MapFrom(s => s.VersionRationale != null ? s.VersionRationale.Text(language) : String.Empty))
                .ForMember(d => d.Records, opt => opt.MapFrom(s => s.LogicalRecords))
                .ForMember(d => d.Components, opt => opt.MapFrom(s => s.Components));
        }
    }
}