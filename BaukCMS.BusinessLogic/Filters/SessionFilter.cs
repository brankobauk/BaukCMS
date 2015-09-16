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

namespace BaukCMS.BusinessLogic.Filters
{
    public class SessionFilter : ActionFilterAttribute, IActionFilter
    {
        private readonly SessionManager _sessionManager = new SessionManager();
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userName = filterContext.HttpContext.User.Identity.Name;
            _sessionManager.SetSession(userName);
        }
    }
}
