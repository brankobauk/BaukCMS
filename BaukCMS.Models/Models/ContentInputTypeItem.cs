using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.Models.Models
{
    public class ContentInputTypeItem
    {
        //itemi za selectboxe, radio buttne
        [Key]
        public int ContentInputTypeItemId { get;set; }
        public int ContentInputTypeId { get; set; }
        public string Name { get; set; }
        public int SiteId { get; set; }
        public virtual Site Site { get; set; }
    }
}
