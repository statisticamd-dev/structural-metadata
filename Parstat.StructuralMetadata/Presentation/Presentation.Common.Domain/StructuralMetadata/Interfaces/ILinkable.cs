using System;
using System.Collections.Generic;
using System.Text;
using Presentation.Domain;

namespace Presentation.Common.Domain.StructuralMetadata.Interfaces
{
    public interface ILinkable : IDomain
    {
        MultilanguageString Link { get; set; }
    }
}
