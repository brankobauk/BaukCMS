using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaukCMS.Models.Models
{
    public class Company
    {
        public Company()
        {
            UserProfiles = new List<UserProfile>();
            CompanySite = new List<CompanySite>();
        }
        [Key]
        public int CompanyId { get; set; }
        [Required]
        public string Name { get; set; }
        private ICollection<UserProfile> UserProfiles { get; set; }
        private ICollection<CompanySite> CompanySite { get; set; }
    }
}