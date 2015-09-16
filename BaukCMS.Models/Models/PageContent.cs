using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.Models.Models
{
    public class PageContent
    {
        [Key]
        public int PageContentId { get; set; }
        public int SiteId { get; set; }
        public int PageId { get; set; }
        public int ContentId { get; set; }
        public int YPlaceId { get; set; }
        public int XPlaceId { get; set; }
        public int OrderNumber { get; set; }
        public virtual Site Site { get; set; }
        public virtual Content Content { get; set; }
        public virtual Page Page { get; set; }
    }
}
