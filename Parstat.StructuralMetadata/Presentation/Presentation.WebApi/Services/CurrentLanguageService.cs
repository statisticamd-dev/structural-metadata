using System;
using Microsoft.AspNetCore.Http;
using Presentation.Application.Common.Interfaces;
using Presentation.Common.Domain.StructuralMetadata.Enums;

namespace Presentation.WebApi.Services
{
    public class CurrentLanguageService : ICurrentLanguageService
    {
        public CurrentLanguageService(IHttpContextAccessor httpContextAccessor) 
        {
            Language = Language.EN; //default
            if(httpContextAccessor.HttpContext.Request.Query.ContainsKey("language"))
            {
                Language language;
                string lng = httpContextAccessor.HttpContext.Request.Query["language"];
                if(Enum.TryParse<Language>(lng, true, out language)) {
                    Language = language;
                }
                
            }
        }
    }
}