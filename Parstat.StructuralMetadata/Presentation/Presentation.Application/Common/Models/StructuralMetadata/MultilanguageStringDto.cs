using System;
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
               En = !String.IsNullOrEmpty(this.En) ? this.En : null,
               Ro = !String.IsNullOrEmpty(this.Ro) ? this.Ro : null,
               Ru = !String.IsNullOrEmpty(this.Ru) ? this.Ru : null
           };
       }
    }
}