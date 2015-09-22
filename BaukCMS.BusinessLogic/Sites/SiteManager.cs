using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaukCMS.DataLayer.Repositories;
using BaukCMS.Models.Models;

namespace BaukCMS.BusinessLogic.Sites
{
    public class SiteManager
    {
        private readonly SiteRepository _siteRepository = new SiteRepository();
        public List<Site> GetSites()
        {
            return _siteRepository.GetSites();
        }

        public void AddSite(Site site)
        {
            _siteRepository.AddSite(site);
        }

        public void EditSite(Site site)
        {
            _siteRepository.EditSite(site);
        }

        public void DeleteSite(int siteId)
        {
            _siteRepository.DeleteSite(siteId);
        }

        public Site GetSite(int siteId)
        {
            return _siteRepository.GetSite(siteId);
        }

        public int GetDefaultSiteId(int? companyId)
        {
            return _siteRepository.GetDefaultSiteId(companyId);
        }
    }
}
