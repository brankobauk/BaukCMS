using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.Models.ViewModels
{
    public class TreeViewModel
    {
        public TreeViewModel()
        {
            Childs = new HashSet<TreeViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TreeViewModel> Childs { get; set; }
    }
}
