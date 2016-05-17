using BaukCMS.BusinessLogic.Contents;
using BaukCMS.Helpers.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaukCMS.UI.Controllers
{
    public class ContentController : Controller
    {
        //
        // GET: /Content/
        private readonly ContentHandler _contentHandler = new ContentHandler();
        public ActionResult AddContent(int pageContentId)
        {
            return PartialView();
        }

        public ActionResult ContentTemplates()
        {
            var contentTemplateViewModel = _contentHandler.GetContentTemplatesViewModel(MySession.Current.SiteId);
            return PartialView(contentTemplateViewModel);
        }

        public ActionResult ContentForm(int contentTemplateId)
        {
            var contentItemsViewModel = _contentHandler.GetContentViewModel(contentTemplateId);
            return PartialView(contentItemsViewModel);
        }

    }
}
