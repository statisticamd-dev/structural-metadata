using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Common.Domain.StructuralMetadata.Interfaces.Gsim
{
    public interface IConcept: IIdentifiableArtefact
    {
        string Definition { get; set; }
    }
}
