using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.Models.Models
{
    public class UserProperty
    {
        [Key]
        public int UserPropertyId { get; set; }
        public int UserId { get; set; }
        public int SiteId { get; set; }
        public virtual Site Site { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
