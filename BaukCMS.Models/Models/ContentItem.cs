using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.Models.Models
{
    public class ContentItem
    {
        [Key]
        public int ContentItemId { get; set; }
        public string ContentItemName { get; set; }
        public int OrderNumber { get; set; }
        public int ContentTemplateId { get; set; }
        public int ContentInputTypeId { get; set; }
        public int ContentInputTypeValueId { get; set; }
        public int SiteId { get; set; }
        public virtual Site Site { get; set; }
        public virtual ContentTemplate ContentTemplate { get; set; }
        public virtual ContentInputType ContentInputType { get; set; }
        public virtual ContentInputTypeValue ContentInputTypeValue { get; set; }

    }
}
