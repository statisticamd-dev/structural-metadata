using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.NoteSets.StatisticalClassifications.Queries.GetStatisticalClassificationDetails
{
    public class LevelDetailsDto : AbstractBaseDto, IMapFrom<Level>
    {
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LevelNumber { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from request
            //default english
            string language = "en";
            profile.CreateMap<Level, LevelDetailsDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name.Text(language)))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description.Text(language)))
                .ForMember(d => d.LevelNumber, opt => opt.MapFrom(s => s.LevelNumber));
        }
    }
}