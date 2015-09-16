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
        private readonly AccountManager _accountManager = new AccountManager();
        public void SetSession(string userName)
        {
            if (MySession.Current.UserId > 0 || string.IsNullOrEmpty(userName)) return;
            var user = _accountManager.GetUserByName(userName);
            MySession.Current.UserId = user.UserId;
            MySession.Current.SiteId = user.LastSiteId;
            MySession.Current.CompanyId = user.LastSiteId;
        }

        public void EndSession()
        {
            MySession.Current.EndSession();
        }
    }
}
