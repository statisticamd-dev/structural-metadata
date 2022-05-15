using System;
using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;

namespace Presentation.Application.DataSets.DimensionalDataSet.Queries.GetDimensionalDataSetDetails
{
    public class DimensionalDataStructureDto : AbstractIdentifiableArtefactDto, IMapFrom<DataStructure>
    {
         public List<DimensionalComponentDto> Components { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from  request
            //default english
            string language = "en";
            profile.CreateMap<DataStructure, DimensionalDataStructureDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name == null ? String.Empty : s.Name.Text(language)))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : String.Empty))
                .ForMember(d => d.VersionRationale, opt => opt.MapFrom(s => s.VersionRationale != null ? s.VersionRationale.Text(language) : String.Empty))
                .ForMember(d => d.Components, opt => {
                    opt.PreCondition(s => s.Components.Count > 0);
                    opt.MapFrom(s => s.Components);
                    opt.NullSubstitute(new List<DimensionalComponentDto>());
                } );
        
        }
    }
}
