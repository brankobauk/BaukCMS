using BaukCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.Models.ViewModels
{
    public class CompanyViewModel
    {
        public Company Company { get; set; }
        public List<CompanySiteConnection> CompanySiteConnections { get; set; }
    }
}
