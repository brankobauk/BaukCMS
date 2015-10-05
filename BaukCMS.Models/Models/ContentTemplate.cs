using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.Models.Models
{
    public class ContentTemplate
    {
        [Key]
        public int ContentTemplateId { get; set; }
        public string ContentTemplateName { get; set; }
        public int SiteId { get; set; }
        public virtual Site Site { get; set; }

    }
}
