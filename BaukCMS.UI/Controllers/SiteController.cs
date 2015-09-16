using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaukCMS.BusinessLogic.Account;
using BaukCMS.BusinessLogic.Errors;
using BaukCMS.BusinessLogic.Sites;
using BaukCMS.Helpers.Errors;
using BaukCMS.Helpers.Mappers;
using BaukCMS.Helpers.Session;
using BaukCMS.Models.Models;
using BaukCMS.Models.ViewModels;
using WebMatrix.WebData;
using BaukCMS.BusinessLogic.Filters;

namespace BaukCMS.UI.Controllers
{
    [Authorize]
    [SessionFilter]
    public class SiteController : Controller
    {
        private readonly SiteHandler _siteHandler = new SiteHandler();
        private readonly ErrorHandler _errorHandler = new ErrorHandler();
        private readonly ErrorMapper _errorMapper = new ErrorMapper();
        private readonly AccountHandler _accountHandler = new AccountHandler();
        //
        // GET: /Site/
        
        public ActionResult Index()
        {
            try
            {
                return View(_siteHandler.GetSites());
            }
            catch (Exception ex)
            {
                var url = "";
                if (Request.Url != null)
                {
                    url = Request.Url.AbsoluteUri;
                }
                _errorHandler.Log(_errorMapper.MapError(ex, url));
                ViewBag.Error = ErrorText.GeneralError;
                return View();
            }
        }

        

        //
        // GET: /Site/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Site/Create

        [HttpPost]
        public ActionResult Create(Site site)
        {
            try
            {
                _siteHandler.AddSite(site);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                var url = "";
                if (Request.Url != null)
                {
                    url = Request.Url.AbsoluteUri;
                }
                _errorHandler.Log(_errorMapper.MapError(ex, url));
                ViewBag.Error = ErrorText.GeneralError;
                return View(site);
            }
        }

        //
        // GET: /Site/Edit/5

        public ActionResult Edit(int id)
        {
            try
            {
                return View(_siteHandler.GetSite(id));
            }
            catch (Exception ex)
            {
                var url = "";
                if (Request.Url != null)
                {
                    url = Request.Url.AbsoluteUri;
                }
                _errorHandler.Log(_errorMapper.MapError(ex, url));
                ViewBag.Error = ErrorText.GeneralError;
                return View();
            }
        }

        //
        // POST: /Site/Edit/5

        [HttpPost]
        public ActionResult Edit(Site site)
        {
            try
            {
                // TODO: Add update logic here
                _siteHandler.EditSite(site);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var url = "";
                if (Request.Url != null)
                {
                    url = Request.Url.AbsoluteUri;
                }
                _errorHandler.Log(_errorMapper.MapError(ex, url));
                ViewBag.Error = ErrorText.GeneralError;
                return View(site);
            }
        }

        //
        // GET: /Site/Delete/5

        public ActionResult Delete(int siteId)
        {
            try
            {
                _siteHandler.DeleteSite(siteId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var url = "";
                if (Request.Url != null)
                {
                    url = Request.Url.AbsoluteUri;
                }
                _errorHandler.Log(_errorMapper.MapError(ex, url));
                ViewBag.Error = ErrorText.GeneralError;
                return RedirectToAction("Index");
            }
        }

        //[Authorize]
        public PartialViewResult SiteDropdown()
        {
            try
            {
                return PartialView(_siteHandler.GetSiteViewModel());
            }
            catch (Exception ex)
            {
                var url = "";
                if (Request.Url != null)
                {
                    url = Request.Url.AbsoluteUri;
                }
                _errorHandler.Log(_errorMapper.MapError(ex, url));
                return PartialView(null);
            }
        }

        //[Authorize]
        [HttpPost]
        public ActionResult SetSiteSession(SiteViewModel siteViewModel)
        {
            try
            {
                var isSet = _accountHandler.SetUserSession(MySession.Current.UserId, siteViewModel.SiteId, MySession.Current.IsAdmin);
                if (isSet)
                {
                    MySession.Current.SiteId = siteViewModel.SiteId;
                }
                else 
                {
                    TempData["Error"] = ErrorText.GeneralError;
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                var url = "";
                if (Request.Url != null)
                {
                    url = Request.Url.AbsoluteUri;
                }
                _errorHandler.Log(_errorMapper.MapError(ex, url));
                return RedirectToAction("Index", "Home");
            }
        }


    }
}
