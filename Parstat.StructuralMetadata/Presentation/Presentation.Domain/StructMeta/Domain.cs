using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Domain.StructMeta
{
    public abstract class Domain
    {
        public string Id { get; set; }
        public string LocalID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string VersionDate { get; set; }
        public string VersionRationale { get; set; }        
    }
}
