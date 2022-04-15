using System;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;

namespace Presentation.Application.DataSets.UnitDataSet.Queries.GetUnitDataSet
{
    public class ComponentMiniDto : AbstractIdentifiableArtefactDto, IMapFrom<Component>
    {

        public ComponentType Type { get; set; }
        public string RepresentationLink { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from  request
            //default english
            string language = "en";
            profile.CreateMap<Component, ComponentMiniDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name == null ? String.Empty : s.Name.Text(language)))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : String.Empty))
                .ForMember(d => d.VersionRationale, opt => opt.MapFrom(s => s.VersionRationale != null ? s.VersionRationale.Text(language) : String.Empty))
                .ForMember(d => d.RepresentationLink, opt => opt.MapFrom(s => "/metadata/structural/variables/representations/view/" + s.RepresentedVariable.Id));
        }
    }
}