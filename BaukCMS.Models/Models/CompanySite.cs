using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.Models.Models
{
    public class CompanySite
    {
        [Key]
        public int CompanySiteId { get; set; }
        public int CompanyId { get; set; }
        public int SiteId { get; set; }
        public virtual Site Site { get; set; }
        public virtual Company Company { get; set; }
    }

    public class CompanySiteConnection
    {
        public int SiteId { get; set; }
        public string  SiteName { get; set; }
        public bool Selected { get; set; }
    }
}
