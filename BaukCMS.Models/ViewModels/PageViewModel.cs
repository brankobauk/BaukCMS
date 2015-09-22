using BaukCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BaukCMS.Models.ViewModels
{
    public class PageViewModel
    {
        public Page Page { get; set; }
        public IEnumerable<SelectListItem> PageType { get; set; }
    }
}
