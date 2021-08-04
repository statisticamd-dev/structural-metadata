using System;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.NoteSets.StatisticalClassifications.Queries.GetStatisticalClassifications
{
    public class StatisticalClassificationDto : IMapFrom<NodeSet>
    {
        public long Id { get; set; }
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Version { get; set; }
        public DateTime VersionDate { get; set; }
        public string VersionRationale { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NodeSet, StatisticalClassificationDto>();
        }
    }

}