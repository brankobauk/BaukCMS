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
            return _db.PageType.AsNoTracking().ToList();
        }

        public List<PageContent> GetPageContents(int pageId)
        {
            return _db.PageContent.Where(p => p.PageId == pageId).OrderBy(p => p.OrderNumber).ToList();
        }

        public PageContent GetPageContent(int pageContentId)
        {
            return _db.PageContent.FirstOrDefault(p => p.PageContentId == pageContentId);
        }

        public List<ContentItemValue> GetContentItemValue(int contentId)
        {
            return _db.ContentItemValue.Where(p => p.ContentId == contentId).ToList();
        }

        public List<Content> GetContents(int pageId)
        {
            throw new NotImplementedException();
        }

        public void EditPageContent(PageContent pageContent)
        {
            var pageContentToEdit = GetPageContent(pageContent.PageContentId);
            pageContentToEdit.OrderNumber = pageContent.OrderNumber;
            pageContentToEdit.YPlaceId = pageContent.YPlaceId;
            pageContentToEdit.XPlaceId = pageContent.XPlaceId;
            _db.SaveChanges();
        }

        public void DeletePageContent(int pageContentId)
        {
            var pageContentToEdit = GetPageContent(pageContentId);
            _db.PageContent.Remove(pageContentToEdit);
            _db.SaveChanges();
        }
    }
}
