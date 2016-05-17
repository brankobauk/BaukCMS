using System.Collections.Generic;
using System.Web.Mvc;
using BaukCMS.Models.Models;

namespace BaukCMS.Models.ViewModels
{
    public class AccountViewModel
    {
        public UserProfile UserProfile { get; set; }
        public IEnumerable<SelectListItem> Companies { get; set; }
        public List<UserRole> UserRole { get; set; }
    }
}
