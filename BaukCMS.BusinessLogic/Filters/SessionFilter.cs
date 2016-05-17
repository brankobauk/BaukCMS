using BaukCMS.Helpers.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using System.Web.Security;
using BaukCMS.BusinessLogic.Sessions;
using BaukCMS.BusinessLogic.Account;
using WebMatrix.WebData;

namespace BaukCMS.BusinessLogic.Filters
{
    public class SessionFilter : ActionFilterAttribute, IActionFilter
    {
        private readonly SessionHandler _sessionHandler = new SessionHandler();
        private readonly AccountHandler _accountHandler = new AccountHandler();
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userName = filterContext.HttpContext.User.Identity.Name;
            var user = _accountHandler.GetUserByName(userName);
            if (!user.Active)
            {
                WebSecurity.Logout();
                _sessionHandler.EndSession();
            }
            _sessionHandler.SetSession(userName);
            
        }
    }
}
