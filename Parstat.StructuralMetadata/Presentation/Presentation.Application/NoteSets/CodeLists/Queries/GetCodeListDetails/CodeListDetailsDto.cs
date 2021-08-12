using System;
using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.NoteSets.CodeLists.Queries.GetCodeListDetails
{
    public class CodeListDetailsDto : IMapFrom<NodeSet>
    {
        public long Id { get; set; }
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public List<CodeItemDto> CodeItems { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from request
            //default english
            string language = "en";
            profile.CreateMap<NodeSet, CodeListDetailsDto>()
                .ForMember(ns => ns.Name, opt => opt.MapFrom(s => s.Name.Text(language)))
                .ForMember(ns => ns.Description, opt => opt.MapFrom(s => s.Description.Text(language)))
                .ForMember(ns => ns.CodeItems, opt => opt.MapFrom(s => s.Nodes));
        }
       
    }
}