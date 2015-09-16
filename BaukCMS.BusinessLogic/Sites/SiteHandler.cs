using System;
using System.Collections.Generic;
using BaukCMS.Helpers.Session;
using BaukCMS.Models.Models;
using BaukCMS.Models.ViewModels;
using BaukCMS.Helpers.DropDownHelpers;

namespace BaukCMS.BusinessLogic.Sites
{
    public class SiteHandler
    {
        private readonly SiteManager _siteManager = new SiteManager();
        private readonly DropDownHelper _dropdownHelper = new DropDownHelper();
        public List<Site> GetSites()
        {
            return _siteManager.GetSites();
        }

        public void AddSite(Site site)
        {
            _siteManager.AddSite(site);
        }

        public void EditSite(Site site)
        {
            _siteManager.EditSite(site);
        }

        public void DeleteSite(int siteId)
        {
            _siteManager.DeleteSite(siteId);
        }

        public Site GetSite(int siteId)
        {
            return _siteManager.GetSite(siteId);
        }

        public SiteViewModel GetSiteViewModel()
        {
            var siteViewModel = new SiteViewModel
            {
                Sites = _dropdownHelper.GetSiteListForDropDown(GetSites()),
                SiteId = MySession.Current.SiteId
            };
            return siteViewModel;
        }
    }
}
