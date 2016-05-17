using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BaukCMS.Models.ViewModels
{
    public class ContentTemplateViewModel
    {
        public IEnumerable<SelectListItem> ContentTemplates { get; set; }
        public int ContentTemplateId { get; set; }
    }
}
