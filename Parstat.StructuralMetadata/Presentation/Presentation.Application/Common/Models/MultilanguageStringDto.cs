using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;

namespace Presentation.Application.Common.Models
{
    public class MultilanguageStringDto : IMapFrom<MultilanguageString>
    {
       public string En { get; set; }
       public string Ro { get; set; }
       public string Ru { get; set; }

       public void Mapping(Profile profile)
        {
            profile.CreateMap<MultilanguageString, MultilanguageStringDto>();
        }
    }
}