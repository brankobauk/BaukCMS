using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaukCMS.BusinessLogic.Account;
using BaukCMS.Helpers.Session;

namespace BaukCMS.BusinessLogic.Sessions
{
    public class SessionHandler
    {
        private readonly SessionManager _sessionManager = new SessionManager();
        public void SetSession(string userName)
        {
            _sessionManager.SetSession(userName); 
        }

        public void EndSession()
        {
            _sessionManager.EndSession();
        }

      
    }
}
