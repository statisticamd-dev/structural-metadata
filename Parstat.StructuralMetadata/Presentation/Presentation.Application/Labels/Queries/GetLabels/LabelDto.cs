using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.Labels.Queries.GetLabels
{
    public class LabelDto : AbstractBaseDto, IMapFrom<Label>
    {
        public string Value { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from  request
            //default english
            string language = "en";
            profile.CreateMap<Label, LabelDto>()
                .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Value.Text(language))
                );
        }
    }
}