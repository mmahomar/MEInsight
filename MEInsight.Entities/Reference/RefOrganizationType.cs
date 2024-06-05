using MEInsight.Entities.Core;
using MEInsight.Entities.Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEInsight.Entities.Reference
{
    public class RefOrganizationType
    {
        public RefOrganizationType()
        {
            Organizations = new HashSet<Organization>();
            Programs = new HashSet<Program>();
        }
        public int RefOrganizationTypeId { get; set; }
        public string? RefOrganizationTypeName { get; set; }

        public string OrganizationTypeCode { get; set; } = null!;
        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual ICollection<Program> Programs { get; set; }
    }
}
