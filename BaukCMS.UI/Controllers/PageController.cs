using BaukCMS.BusinessLogic.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaukCMS.Helpers.Session;
using BaukCMS.Models.Models;
using BaukCMS.Models.ViewModels;

namespace BaukCMS.UI.Controllers
{
    public class PageController : Controller
    {
        //
        // GET: /Page/
        private readonly PageHandler _pageHandler = new PageHandler();
        public ActionResult Index()
        {
            var tree = _pageHandler.GetPagesTree(MySession.Current.SiteId);
            return View(tree);
        }

        //
        // GET: /Page/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Page/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Page/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Page/Edit/5

        public ActionResult Edit(int id)
        {

            return PartialView(_pageHandler.GetPageViewModel(id));
        }

        //
        // POST: /Page/Edit/5

        [HttpPost]
        public JsonResult Edit(Page page)
        {
            try
            {
                _pageHandler.EditPage(page);

                return Json(_pageHandler.GetPageViewModel(page.PageId));
            }
            catch
            {
                return Json(_pageHandler.GetPageViewModel(page.PageId));
            }
        }

        //
        // GET: /Page/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Page/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public string EditTree(int? pageId, int parentId, int position, string pageName, string action)
        {
            try
            {
                return _pageHandler.EditTree(pageId, parentId, position, pageName, action);
            }
            catch
            {
                return "";
            }
        }

        public ActionResult GetContents(int pageId)
        {
            var pageContent = _pageHandler.GetPageContents(pageId);
            return PartialView(pageContent);
        }

        public void MovePageContent(int pageId, int pageContentId, int yPlaceId, int xPlaceId, int orderNumber)
        {
            _pageHandler.MovePageContent(pageId, pageContentId, yPlaceId, xPlaceId, orderNumber);
        }

        public void DeletePageContent(int pageId, int pageContentId, int yPlaceId, int xPlaceId)
        {
            _pageHandler.DeletePageContent(pageId, pageContentId, yPlaceId, xPlaceId);
        }
    }
}
