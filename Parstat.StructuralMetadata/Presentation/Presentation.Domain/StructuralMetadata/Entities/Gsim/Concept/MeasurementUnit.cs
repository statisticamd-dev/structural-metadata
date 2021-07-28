using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using System.Collections.Generic;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept
{
    public class MeasurementUnit : AbstractIdentifiableArtefact
    {
        public MeasurementUnit() {
            ValueDomains = new HashSet<ValueDomain>();
        }
        public string Abbreviation { get; set; }
        public string ConvertionRule { get; set; }
        public long StandardId { get; set; }
        public ValueDomain Standard { get; set; }
        public IEnumerable<ValueDomain> ValueDomains { get; set; }
    
    }
}