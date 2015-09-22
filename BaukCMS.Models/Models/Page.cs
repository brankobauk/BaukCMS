using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.Models.Models
{
    public class Page
    {
        public Page()
        {
            PageContent = new List<PageContent>();
        }
        [Key]
        public int PageId { get; set; }
        public int SiteId { get; set; }
        public string Name { get; set; }
        public string UrlPath { get; set; }
        public virtual Site Site { get; set; }
        public int ParentId { get; set; }
        public int PageTypeId { get; set; }
        public int OrderNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active{ get; set; }
        public virtual ICollection<PageContent> PageContent { get; set; }
        public virtual PageType PageType { get; set; }
    }
}
