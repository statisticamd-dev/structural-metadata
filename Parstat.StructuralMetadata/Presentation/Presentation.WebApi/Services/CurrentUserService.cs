using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using Presentation.Application.Common.Interfaces;

namespace Presentation.WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            StringValues jwtHeader = new StringValues();
            IsAuthenticated = httpContextAccessor.HttpContext?.Request.Headers.TryGetValue("jwt-auth", out jwtHeader) ?? false;
            if (IsAuthenticated)
            {
                UserId = getUser(jwtHeader);
            }
            else
            {
                UserId = null;
            }
        }
        private string getUser(StringValues jwtHeader) {
            var base64EncodedBytes = WebEncoders.Base64UrlDecode(jwtHeader.ToString().Split(".")[1]);
                string jwt = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                var options = new JsonDocumentOptions
                {
                    AllowTrailingCommas = true
                };
                using(JsonDocument document = JsonDocument.Parse(jwt)) {
                    return document.RootElement.EnumerateObject()
                        .Where(u => u.Name == "user")
                        .FirstOrDefault().Value.ToString();
                }
        } 
        public string UserId { get; }

        public bool IsAuthenticated { get; }
    }
}