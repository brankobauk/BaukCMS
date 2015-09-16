using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BaukCMS.Helpers.Session
{
    public class MySession
    {
        //private constructor
        private MySession()
        {

        }

        // Gets the current session.
        public static MySession Current
        {
            get
            {
                MySession session =
                (MySession)HttpContext.Current.Session["__MySession__"];
            if (session == null)
            {
                session = new MySession();
                HttpContext.Current.Session["__MySession__"] = session;
            }
            return session;
            }
        }
        public void EndSession()
        {
            HttpContext.Current.Session["__MySession__"] = null;
        }
        // **** add your session properties here, e.g like this:
        
        public int SiteId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
