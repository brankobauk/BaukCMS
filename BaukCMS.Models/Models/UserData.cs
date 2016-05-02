using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.Models.Models
{
    public class UserData
    {
        public int UserDataId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CompanyId { get; set; }
        public bool Active { get; set; }
        public int LastSiteId { get; set; }
        public virtual Company Company { get; set; }
        public virtual UserProfile UserProfile { get; set; }

    }
}
