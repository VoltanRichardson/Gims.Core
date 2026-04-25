using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gims.Core.Policy
{
    public class CoverageType
    {
        public Guid CoverageTypeId { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }

        private CoverageType() { }

        public CoverageType(string name, string? description = null)
        {
            CoverageTypeId = Guid.NewGuid();
            Name = name;
            Description = description;
        }
    }
}