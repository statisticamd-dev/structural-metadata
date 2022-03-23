
using Presentation.Common.Domain.StructuralMetadata.Enums;
using System;

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

        public string Text(string language) 
        {
            Language lng;
            if(Enum.TryParse<Language>(language, true, out lng)) 
            {
                return Text(lng);
            }
            return Text(Language.EN); //default
        }

        public static MultilanguageString Init(Language language, string text) 
        {
            if(language == Language.RO)
                if(!String.IsNullOrEmpty(text))
                    return new MultilanguageString {Ro = text};
                else
                    return new MultilanguageString {Ro = ""};
            if(language == Language.RU) 
                if(!String.IsNullOrEmpty(text))
                    return new MultilanguageString {Ru = text};
                else    
                    return new MultilanguageString {Ru = ""};
            if(!String.IsNullOrEmpty(text))
                return new MultilanguageString {En = text};
            return new MultilanguageString {En = ""};
        }

        public void AddText(Language language, string text) 
        {
            if(!String.IsNullOrWhiteSpace(text))
            {
                if(language == Language.RO)
                    this.Ro = text;
                if(language == Language.RU)
                    this.Ru = text;
                if(language == Language.EN)
                    this.En = text;
            }
        }
    }
}