using BaukCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.Models.ViewModels
{
    public class ContentItemValueViewModel
    {
        public List<ContentItemValue> ContentItemValues { get; set; }
        public Content Content { get; set; }
    }
}
