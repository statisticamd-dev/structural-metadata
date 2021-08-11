using AutoMapper;
using Presentation.Domain;

namespace Presentation.Application.Common.Converters
{
    public class Translation : IValueConverter<MultilanguageString, string>
    {
        public string Convert(MultilanguageString source,  ResolutionContext context) 
        {
            return source.En;
        }
    }
}