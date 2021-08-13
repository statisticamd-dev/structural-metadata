using System;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.NoteSets.StatisticalClassifications.Queries.GetStatisticalClassifications
{
    public class StatisticalClassificationDto : AbstractConceptDto, IMapFrom<NodeSet>
    {

        public void Mapping(Profile profile)
        {
            //language parameter from request
            //default english
            string language = "en";
            profile.CreateMap<NodeSet, StatisticalClassificationDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name.Text(language)))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description.Text(language)))
                .ForMember(d => d.VersionRationale, opt => opt.MapFrom(s => s.VersionRationale.Text(language)))
                .ForMember(d => d.Definition, opt => opt.MapFrom(s => s.Definition.Text(language)))
                .ForMember(d => d.Link, opt => opt.MapFrom(s => s.Link));
        }
    }

}