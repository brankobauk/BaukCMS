using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaukCMS.DataLayer.Context;
using BaukCMS.Models.Models;

namespace BaukCMS.DataLayer.Repositories
{
    public class SiteRepository
    {
        private readonly BaukCMSContext _db = new BaukCMSContext();
        public List<Site> GetSites()
        {
            return _db.Site.ToList();
        }

        public void AddSite(Site site)
        {
            _db.Site.Add(site);
            _db.SaveChanges();
        }

        public void EditSite(Site site)
        {
            var siteToEdit = GetSite(site.SiteId);
            if (siteToEdit == null) return;
            siteToEdit.Name = site.Name;
            siteToEdit.Domain = site.Domain;
            _db.SaveChanges();
        }

        public void DeleteSite(int siteId)
        {
            var siteToDelete = GetSite(siteId);
            _db.Site.Remove(siteToDelete);
            _db.SaveChanges();
        }

        public Site GetSite(int siteId)
        {
            return _db.Site.FirstOrDefault(p => p.SiteId == siteId);
        }

        public int GetDefaultSiteId(int? companyId)
        {
            if (companyId != null)
            {
                return _db.CompanySite.FirstOrDefault(p => p.CompanyId == companyId).SiteId;
            }
            else
            {
                return 0;
            }
        }
    }
}
