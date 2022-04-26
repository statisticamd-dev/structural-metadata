using System;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;

namespace Presentation.Application.DataStructures.Queries.GetDataStructureDetails
{
    public class RecordTinyDto : AbstractBaseDto, IMapFrom<LogicalRecord>
    {
        public string LocalId { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from  request
            //default english
            string language = "en";
            profile.CreateMap<LogicalRecord, RecordTinyDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name != null ? s.Name.Text(language) : String.Empty));
        }
    }
}