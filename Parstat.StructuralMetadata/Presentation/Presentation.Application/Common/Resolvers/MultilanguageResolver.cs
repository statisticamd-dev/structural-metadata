using AutoMapper;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Models;
using Presentation.Domain;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using System;
using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;

namespace Presentation.Application.Common.Resolvers
{
    public class MultilanguageResolver : IValueResolver<object, object, string>
    {
       
        public string Resolve(object source, object destination, string destinationMember, ResolutionContext context)
        {
           return "Test";
        
        }
    }
}