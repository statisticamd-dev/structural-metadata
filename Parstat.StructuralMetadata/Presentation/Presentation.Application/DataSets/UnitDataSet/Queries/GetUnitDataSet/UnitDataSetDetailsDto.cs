using System;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;

namespace Presentation.Application.DataSets.UnitDataSet.Queries.GetUnitDataSet
{
    public class UnitDataSetDto : AbstractIdentifiableArtefactDto, IMapFrom<DataSet>
    {
        public string FilterExpression { get; set; }
        public DateTime ReportingBegin { get; set; }
        public DateTime ReporitngEnd { get; set; }
        public string Connection { get; set; }
        public DataSetType Type { get; set; }
        public ExchangeChannel ExchangeChannel { get; set; }
        public ExchangeDirection ExchangeDirection { get; set; }
        public string StatisticalProgramLink { get; set; }
        public DataStructureMiniDto Structure { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from  request
            //default english
            string language = "en";
            profile.CreateMap<DataSet, UnitDataSetDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name == null ? String.Empty : s.Name.Text(language)))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : String.Empty))
                .ForMember(d => d.VersionRationale, opt => opt.MapFrom(s => s.VersionRationale != null ? s.VersionRationale.Text(language) : String.Empty))
                .ForMember(d => d.StatisticalProgramLink, otp => otp.MapFrom(s => "/metadata/referntial/view/" + s.StatisticalProgramId))
                .ForMember(d => d.Structure, opt => opt.MapFrom(s => s.Structure != null ? s.Structure : null));
        }

    }
}
