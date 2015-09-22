using BaukCMS.BusinessLogic.Account;
using BaukCMS.Helpers.Session;
using BaukCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.BusinessLogic.Sessions
{
    public class SessionManager
    {
        public void SetSession(UserProfile user)
        {
            MySession.Current.UserId = user.UserId;
            MySession.Current.SiteId = user.LastSiteId;
            MySession.Current.CompanyId = Convert.ToInt32(user.CompanyId);
        }

        public void EndSession()
        {
            MySession.Current.EndSession();
        }
    }
}
