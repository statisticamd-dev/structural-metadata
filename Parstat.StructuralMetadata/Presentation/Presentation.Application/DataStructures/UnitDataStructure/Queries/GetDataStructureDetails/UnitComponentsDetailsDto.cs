using System;
using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Application.DataStructures.Common.GetDataStructureDetails;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;

namespace Presentation.Application.DataStructures.UnitDataStructure.Queries.GetDataStructureDetails
{
    public class UnitComponentsDetailsDto : AbstractIdentifiableArtefactDto, IMapFrom<Component>
    {
        public ComponentType Type { get; set; }
        public Boolean? IsIdentifierUnique { get; set; }
        public Boolean? IsIdentifierComposite { get; set; }
        public IdentifierRole? IdentifierRole { get; set; }
        public Boolean? IsAttributeMandatory { get; set; }
        public AttributeAttachmentLevel? AttributeAttachmentLevel { get; set; }
        public RepresentationTinyDto Representation { get; set; }
        public List<RecordTinyDto> Records { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from  request
            //default english
            string language = "en";
            profile.CreateMap<Component, UnitComponentsDetailsDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name != null ? s.Name.Text(language) : String.Empty))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : String.Empty))
                .ForMember(d => d.VersionRationale, opt => opt.MapFrom(s => s.VersionRationale != null ? s.VersionRationale.Text(language) : String.Empty))
                .ForMember(d => d.Representation, opt => opt.MapFrom(s => s.RepresentedVariable))
                .ForMember(d => d.Records, opt => opt.MapFrom(s => s.Records));
        }
    }
}