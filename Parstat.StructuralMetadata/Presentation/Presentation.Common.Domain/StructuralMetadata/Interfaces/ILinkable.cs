using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Common.Domain.StructuralMetadata.Interfaces
{
    public interface ILinkable : IDomain
    {
        string Link { get; set; }
    }
}
