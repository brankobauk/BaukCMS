using BaukCMS.Models.Models;
using BaukCMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.Helpers.Tree
{
    public class TreeHelper
    {
        public List<TreeViewModel> GetPagesTree(List<Page> pages)
        {
            var rootPages = pages.Where(p=>p.ParentId == 0).OrderBy(p=>p.OrderNumber).ToList();
            return GetChilderns(pages, rootPages);
        }

        private List<TreeViewModel> GetChilderns(List<Page> pages, List<Page> childs)
        {
            var tree = new List<TreeViewModel>();
            foreach (var child in childs)
            {
                var childrens = pages.Where(p => p.ParentId == child.PageId).ToList();
                var treeItem = new TreeViewModel();
                treeItem.Name = child.Name;
                treeItem.Id = child.PageId;
                if (childs.Count > 0)
                {
                    treeItem.Childs = GetChilderns(pages, childrens);
                }

                tree.Add(treeItem);
            }
            return tree;
        }
    }
}
