using System;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;

namespace Presentation.Application.DataSets.UnitDataSet.Queries.GetUnitDataSetDetails
{
    public class ComponentDto : AbstractIdentifiableArtefactDto, IMapFrom<Component>
    {
        public ComponentType Type { get; set; }
        public RepresentationMiniDto Representation { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from  request
            //default english
            string language = "en";
            profile.CreateMap<Component, ComponentDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name == null ? String.Empty : s.Name.Text(language)))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : String.Empty))
               /*  .ForMember(d => d.Representation, opt => opt.MapFrom(s => s.RepresentedVariable)) */;
        }
    }
}
