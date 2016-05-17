using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BaukCMS.Models.ViewModels
{
    public class SiteViewModel
    {
        public int SiteId { get; set; }
        public IEnumerable<SelectListItem> Sites { get; set; }
    }
}
