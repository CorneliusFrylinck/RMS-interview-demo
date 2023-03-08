using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanidateApp.Shared
{
    public class SiteAssignment
    {
        public int Id { get; set; }
        public Guid SiteId { get; set; } = Guid.Empty;
        public string Contractor { get; set; } = null!;
    }
}
