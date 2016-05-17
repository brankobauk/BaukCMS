using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.Models.Models
{
    public class MediaCategory
    {
        public MediaCategory()
        {
            ChildMediaCategory = new List<MediaCategory>();
        }

        [Key]
        public int MediaCategoryId { get; set; }
        public int SiteId { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public virtual Site Site { get; set; }
        [ForeignKey("ParentId")]
        public virtual List<MediaCategory> ChildMediaCategory { get; set; }
    }
}
