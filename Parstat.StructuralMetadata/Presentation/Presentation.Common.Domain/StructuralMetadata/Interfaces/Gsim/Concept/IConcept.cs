using System;
using System.Collections.Generic;
using System.Text;
using Presentation.Domain;

namespace Presentation.Common.Domain.StructuralMetadata.Interfaces.Gsim.Concept
{
    public interface IConcept: IIdentifiableArtefact, ILinkable
    {
        MultilanguageString Definition { get; set; }

    }
}
