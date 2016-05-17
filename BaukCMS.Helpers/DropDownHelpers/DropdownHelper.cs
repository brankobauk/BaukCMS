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

        public IEnumerable<SelectListItem> GetPageTypeListForDropDown(List<PageType> pageTypes)
        {
            return pageTypes.Select(pageType => new SelectListItem { Value = pageType.PageTypeId.ToString(CultureInfo.InvariantCulture), Text = pageType.Name.ToString(CultureInfo.InvariantCulture) }).ToList();
       
        }

        public IEnumerable<SelectListItem> GetContentTemplateListForDropDown(List<ContentTemplate> contentTemplates)
        {
            var items = new List<SelectListItem>();
            var item = new SelectListItem()
            {
                Value = "0",
                Text = "--- Choose ---",
                Selected = true
            };
            items.Add(item);
            items.AddRange(contentTemplates.Select(contentTemplate => new SelectListItem { Value = contentTemplate.ContentTemplateId.ToString(CultureInfo.InvariantCulture), Text = contentTemplate.ContentTemplateName.ToString(CultureInfo.InvariantCulture) }).ToList());
            return items;

        }
    }
}
