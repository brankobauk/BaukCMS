using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using BaukCMS.Models.Models;

namespace BaukCMS.Helpers.DropDownHelpers
{
    public class DropDownHelper
    {
        public IEnumerable<SelectListItem> GetCompanyListForDropDown(List<Company> companies)
        {
            return companies.Select(company => new SelectListItem { Value = company.CompanyId.ToString(CultureInfo.InvariantCulture), Text = company.Name.ToString(CultureInfo.InvariantCulture) }).ToList();
        }

        public IEnumerable<SelectListItem> GetSiteListForDropDown(List<Site> sites)
        {
            return sites.Select(site => new SelectListItem { Value = site.SiteId.ToString(CultureInfo.InvariantCulture), Text = site.Name.ToString(CultureInfo.InvariantCulture) }).ToList();
        }
    }
}
