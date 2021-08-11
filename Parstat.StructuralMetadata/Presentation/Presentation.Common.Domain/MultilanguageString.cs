
using Presentation.Common.Domain.StructuralMetadata.Enums;

namespace Presentation.Domain
{
    public class MultilanguageString
    {
        public string En { get; set; }
        public string Ro { get; set; }
        public string Ru { get; set; }

        public string Text(Language language) 
        {
            if(language == Language.EN)
                return this.En;
            if(language == Language.RO)
                return this.Ro;
            if(language == Language.RU)
                return this.Ru;
            return this.En;
        }
    }
}