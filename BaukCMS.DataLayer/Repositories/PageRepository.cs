using BaukCMS.DataLayer.Context;
using BaukCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.DataLayer.Repositories
{
    public class PageRepository
    {
        private readonly BaukCMSContext _db = new BaukCMSContext();
        public List<Page> GetPages(int siteId)
        {
            return _db.Page.Where(p => p.SiteId == siteId).OrderBy(p=>p.OrderNumber).ToList();
        }

        public Page GetPage(int pageId)
        {
            return _db.Page.FirstOrDefault(p => p.PageId == pageId);
        }

        public void EditPage(Page page)
        {
            var pageToEdit = GetPage(page.PageId);
            pageToEdit.OrderNumber = page.OrderNumber;
            pageToEdit.ParentId = page.ParentId;
            pageToEdit.Name = page.Name;
            pageToEdit.PageTypeId = page.PageTypeId;
            pageToEdit.UrlPath = page.UrlPath;
            _db.SaveChanges();
        }

        public void DeletePage(int? pageId)
        {
            var pageToDelete = GetPage(Convert.ToInt32(pageId));
            _db.Page.Remove(pageToDelete);
            _db.SaveChanges();
        }

        public int CreatePage(int parentId, string pageName, int position, int siteId)
        {
            var page = new Page();
            page.ParentId = parentId;
            page.Name = pageName;
            page.OrderNumber = position;
            page.PageTypeId = 1;
            page.SiteId = siteId;
            page.StartDate = DateTime.Now;
            page.EndDate = DateTime.MaxValue;
            _db.Page.Add(page);
            _db.SaveChanges();
            return page.PageId;
        }

        public List<PageType> GetPageTypes()
        {
            return _db.PageType.ToList();
        }
    }
}
