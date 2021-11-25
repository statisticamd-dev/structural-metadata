using System;
using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.NoteSets.CodeLists.Queries.GetCodeListDetails
{
    public class CodeListDetailsDto : AbstractConceptDto, IMapFrom<NodeSet>
    {
        public List<CodeItemDto> CodeItems { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from request
            //default english
            string language = "en";
            profile.CreateMap<NodeSet, CodeListDetailsDto>()
                .ForMember(ns => ns.Name, opt => opt.MapFrom(s => s.Name != null ? s.Name.Text(language) : String.Empty))
                .ForMember(ns => ns.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : String.Empty))
                .ForMember(ns => ns.Definition, opt => opt.MapFrom(s => s.Definition != null ? s.Definition.Text(language) : String.Empty))
                .ForMember(ns => ns.VersionRationale, opt => opt.MapFrom(s => s.VersionRationale != null ? s.VersionRationale.Text(language) : String.Empty))
                .ForMember(ns => ns.Link, opt => opt.MapFrom(s => s.Link != null ? s.Link.Text(language) : String.Empty))
                .ForMember(ns => ns.CodeItems, opt => opt.MapFrom(s => s.Nodes));
        }
       
    }
}