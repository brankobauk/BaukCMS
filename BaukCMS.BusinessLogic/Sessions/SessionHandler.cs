using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaukCMS.BusinessLogic.Account;
using BaukCMS.Helpers.Session;
using BaukCMS.BusinessLogic.Sites;

namespace BaukCMS.BusinessLogic.Sessions
{
    public class SessionHandler
    {
        private readonly SessionManager _sessionManager = new SessionManager();
        private readonly AccountManager _accountManager = new AccountManager();
        private readonly SiteManager _siteManager = new SiteManager();
        public void SetSession(string userName)
        {
            if (string.IsNullOrEmpty(userName)) return;
            var user = _accountManager.GetUserByName(userName);
            if (user.LastSiteId == 0)
            {
                user.LastSiteId = _siteManager.GetDefaultSiteId(user.CompanyId);
            }

            _sessionManager.SetSession(user); 
        }

        public void EndSession()
        {
            _sessionManager.EndSession();
        }

      
    }
}
