using System.ComponentModel.DataAnnotations;

namespace BaukCMS.Models.Models
{
    public class Form
    {
        [Key]
        public int FormId { get; set; }
        public int SiteId { get; set; }
        public int FormCategoryId { get; set; }
        public string Name { get; set; }
        public string Xml { get; set; }
        public virtual Site Site { get; set; }
        public virtual FormCategory FormCategory { get; set; }
    }
}
