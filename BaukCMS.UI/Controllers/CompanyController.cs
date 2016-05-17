using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaukCMS.BusinessLogic.Companies;
using BaukCMS.Models.Models;
using BaukCMS.Models.ViewModels;

namespace BaukCMS.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CompanyController : Controller
    {
        private readonly CompanyHandler _companyHandler = new CompanyHandler();

        //
        // GET: /Company/

        public ActionResult Index()
        {
            return View(_companyHandler.GetCompanies());
        }

        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(Company company)
        {
            try
            {
                _companyHandler.AddCompany(company);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(company);
            }
        }

        public ActionResult Edit(int id)
        {
            var companyViewModel = _companyHandler.GetCompanyViewModel(id);
            return View(companyViewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, CompanyViewModel companyViewModel)
        {
            try
            {
                _companyHandler.EditCompany(id, companyViewModel);
                return RedirectToAction("Index"); 
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _companyHandler.DeleteCompany(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        //public PartialViewResult CreateDropDown()
        //{
        //    return PartialView("_CompanyDropDown", _companyHandler.GetCompaniesForDropDown());
        //}
    }
}
