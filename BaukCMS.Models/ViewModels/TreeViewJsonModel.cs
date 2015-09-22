using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.Models.ViewModels
{
    public class TreeViewJsonModel
    {
        public int Id { get; set; }
        public int Parent { get; set; }
        public string Text { get; set; }
    }
}
