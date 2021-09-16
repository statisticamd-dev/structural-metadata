using System.Collections.Generic;
using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept
{
    public class MeasurementType : AbstractIdentifiableArtefact
    {
        public MeasurementType() 
        {
            MeasureUnits = new HashSet<MeasurementUnit>();
        }
        public IEnumerable<MeasurementUnit> MeasureUnits {get; set;}
    }
}