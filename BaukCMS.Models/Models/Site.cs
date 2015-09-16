using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaukCMS.Models.Models
{
    public class Site
    {
        public Site()
        {
            UserProperty = new List<UserProperty>();
            Page = new List<Page>();
            Content = new List<Content>();
            PageContent = new List<PageContent>();
            MediaCategory = new List<MediaCategory>();
            Media = new List<Media>();
            Form = new List<Form>();
            FormCategory = new List<FormCategory>();
            CompanySite = new List<CompanySite>();
        }
        [Key]
        public int SiteId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Domain { get; set; }
        private ICollection<UserProperty> UserProperty { get; set; }
        private ICollection<Page> Page { get; set; }
        private ICollection<Content> Content { get; set; }
        private ICollection<PageContent> PageContent { get; set; }
        private ICollection<MediaCategory> MediaCategory { get; set; }
        private ICollection<Media> Media { get; set; }
        private ICollection<Form> Form { get; set; }
        private ICollection<FormCategory> FormCategory { get; set; }
        private ICollection<CompanySite> CompanySite { get; set; }
    }
}
