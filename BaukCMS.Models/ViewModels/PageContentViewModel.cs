using BaukCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.Models.ViewModels
{
    public class PageContentViewModel
    {
        public Page Page { get; set; }
        public List<Content> Content { get; set; }
    }
}
