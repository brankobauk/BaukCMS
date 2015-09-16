using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.Models.Models
{
    public class Content
    {
        public Content()
        {
            PageContent = new List<PageContent>();
        }
        [Key]
        public int ContentId { get; set; }
        public int SiteId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public virtual Site Site { get; set; }
        public virtual ICollection<PageContent> PageContent { get; set; }
    }
}
