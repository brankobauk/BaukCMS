using BaukCMS.BusinessLogic.Account;
using BaukCMS.Helpers.Session;
using BaukCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace BaukCMS.BusinessLogic.Sessions
{
    public class SessionManager
    {
        public void SetSession(UserProfile user)
        {
            var admins = Roles.GetUsersInRole("Admin");
            MySession.Current.UserId = user.UserId;
            MySession.Current.SiteId = user.LastSiteId;
            MySession.Current.CompanyId = Convert.ToInt32(user.CompanyId);
            if (admins.Contains(user.UserName))
            {
                MySession.Current.IsAdmin = true;
            }
        }

        public void EndSession()
        {
            MySession.Current.EndSession();
        }
    }
}
