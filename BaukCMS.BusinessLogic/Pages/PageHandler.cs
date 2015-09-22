using BaukCMS.Helpers.DropDownHelpers;
using BaukCMS.Helpers.Errors;
using BaukCMS.Helpers.Session;
using BaukCMS.Helpers.Tree;
using BaukCMS.Models.Models;
using BaukCMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.BusinessLogic.Pages
{
    public class PageHandler
    {
        private readonly PageManager _pageManager = new PageManager();
        private readonly TreeHelper _treeHelper = new TreeHelper();
        private readonly DropDownHelper _dropdownHelper = new DropDownHelper();
        public List<TreeViewModel> GetPagesTree(int siteId)
        {
            var pages =  _pageManager.GetPages(siteId);
            return _treeHelper.GetPagesTree(pages);
        }
        public Page GetPage(int pageId)
        {
            return _pageManager.GetPage(pageId);
        }

        public List<Page> GetPages(int siteId)
        {
            return _pageManager.GetPages(siteId);
        }

        public void EditPage(Page page)
        {
            _pageManager.EditPage(page);
        }
        public string EditTree(int? pageId, int parentId, int position, string pageName, string action)
        {
            var returnText = "";
            switch (action)
            { 
                case "move" : returnText = MovePage(pageId, parentId, position);
                    break;
                case "rename": returnText = RenamePage(pageId, pageName);
                    break;
                case "delete": returnText = DeletePage(pageId, parentId);
                    break;
                case "create": returnText = CreatePage(pageId, parentId, pageName);
                    break;
            }

            return returnText;
        }

        private string CreatePage(int? pageId, int parentId, string pageName)
        {
            var pages = GetPages(MySession.Current.SiteId).Where(p => p.ParentId == parentId);
            var position = pages.Count() + 1;
            return _pageManager.CreatePage(parentId, pageName, position, MySession.Current.SiteId).ToString();
             
        }

        private string DeletePage(int? pageId, int parentId)
        {
            var pages = GetPages(MySession.Current.SiteId).Where(p => p.ParentId == Convert.ToInt32(pageId));
            if (pages.Count() > 0)
            {
                return ErrorText.SubItemDeleteError;
            }
            else 
            {
                _pageManager.DeletePage(pageId);
                return "";
            }
            
        }

        private string RenamePage(int? pageId, string pageName)
        {
            var page = GetPage(Convert.ToInt32(pageId));
            page.Name = pageName;
            EditPage(page);
            return "";
        }

        private string MovePage(int? pageId, int newParentId, int position)
        {
            var pages = GetPages(MySession.Current.SiteId);
            var page = pages.FirstOrDefault(p => p.PageId == pageId);
            if (page.ParentId == newParentId)
            {
                if (page.OrderNumber > position)
                {
                    position++;
                }
                SaveOrder(page, page.PageId, newParentId, position, pages);
            }
            else 
            {
                SaveOrder(null, page.PageId, page.ParentId, position, pages);
                position++;
                SaveOrder(page, page.PageId, newParentId, position, pages);
            }
            return "";
        }

        private void SaveOrder(Page page, int pageId, int newParentId, int orderNumber, List<Page> pages)
        {
            var isPageUpdated = false;
            var pagesToOrder = pages.Where(p => p.ParentId == newParentId && p.PageId != pageId).OrderBy(p => p.OrderNumber).ToList();
            var i = 1;
            foreach (var p in pagesToOrder)
            {
                if (orderNumber == i && page != null)
                {
                    EditPage(PreparePage(page, orderNumber, newParentId));
                    i++;
                    isPageUpdated = true;
                }
                p.OrderNumber = i++;
                EditPage(p);
            }
            if (!isPageUpdated && page != null)
            {
                EditPage(PreparePage(page, orderNumber, newParentId));
            }
            
        }

        private Page PreparePage(Page page, int orderNumber, int parentId)
        {
            page.OrderNumber = orderNumber;
            page.ParentId = parentId;
            return page;
        }

        public PageViewModel GetPageViewModel(int pageId)
        {
            var pageViewModel = new PageViewModel
            {
                PageType = _dropdownHelper.GetPageTypeListForDropDown(GetPageTypes()),
                Page = GetPage(pageId)
            };
            return pageViewModel;
        }

        private List<PageType> GetPageTypes()
        {
            return _pageManager.GetPageTypes();
        }
    }
}
