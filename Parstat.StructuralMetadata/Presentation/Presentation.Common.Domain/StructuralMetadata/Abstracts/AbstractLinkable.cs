using Presentation.Common.Domain.StructuralMetadata.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Common.Domain.StructuralMetadata.Abstracts
{
    public abstract class AbstractLinkable : AbstractDomain, ILinkable
    {
        public string Link { get; set; }
    }
}
