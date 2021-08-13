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
                .ForMember(ns => ns.Name, opt => opt.MapFrom(s => s.Name.Text(language)))
                .ForMember(ns => ns.Description, opt => opt.MapFrom(s => s.Description.Text(language)))
                .ForMember(ns => ns.Definition, opt => opt.MapFrom(s => s.Definition.Text(language)))
                .ForMember(ns => ns.VersionRationale, opt => opt.MapFrom(s => s.VersionRationale.Text(language)))
                .ForMember(ns => ns.Link, opt => opt.MapFrom(s => s.Link.Text(language)))
                .ForMember(ns => ns.CodeItems, opt => opt.MapFrom(s => s.Nodes));
        }
       
    }
}