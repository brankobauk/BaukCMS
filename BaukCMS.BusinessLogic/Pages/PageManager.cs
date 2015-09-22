using BaukCMS.DataLayer.Repositories;
using BaukCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.BusinessLogic.Pages
{
    public class PageManager
    {
        private readonly PageRepository _pageRepository = new PageRepository();
        public  List<Page> GetPages(int siteId)
        {
            return  _pageRepository.GetPages(siteId);
        }

        public void EditPage(Page page)
        {
            _pageRepository.EditPage(page);
        }

        public Page GetPage(int pageId)
        {
            return _pageRepository.GetPage(pageId);
        }

        public void DeletePage(int? pageId)
        {
            _pageRepository.DeletePage(pageId);
        }

        public int CreatePage(int parentId, string pageName, int position, int siteId)
        {
            return _pageRepository.CreatePage(parentId, pageName, position, siteId);
        }

        public List<PageType> GetPageTypes()
        {
            return _pageRepository.GetPageTypes();
        }
    }
}
