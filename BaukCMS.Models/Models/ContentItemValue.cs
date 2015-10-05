using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.Models.Models
{
    public class ContentItemValue
    {
        [Key]
        public int ContentInputValueId { get; set; }
        public int ContentId { get; set; }
        public int ContentItemId { get; set; }
        public string Value { get; set; }
        public int SiteId { get; set; }
        public virtual Content Content { get; set; }
        public virtual Site Site { get; set; }
        public virtual ContentItem ContentItem { get; set; }

    }
}
