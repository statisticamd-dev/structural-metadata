using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using System.Collections.Generic;

namespace Presentation.Domain.StructuralMetadata.Gsim.Concept
{
    public class MeasurementUnit : AbstractIdentifiableArtefact
    {
        public string Abbreviation { get; set; }

        public string ConvertionRule { get; set; }

        public SubstantiveValueDomain Standard { get; set; }

        public IEnumerable<SubstantiveValueDomain> SubstantiveValueDomains { get; set; }
    
    }
}