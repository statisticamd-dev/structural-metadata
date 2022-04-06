using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Domain;

namespace Presentation.Application.Common.Models.StructuralMetadata
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

       public MultilanguageString asMUltilanguageString() 
       {
           return new MultilanguageString() 
           {
               En = this.En,
               Ro = this.Ro,
               Ru = this.Ru
           };
       }
    }
}