using System.Collections.Generic;
using BaukCMS.Models.Models;
using BaukCMS.Models.ViewModels;
using BaukCMS.BusinessLogic.Sites;

namespace BaukCMS.BusinessLogic.Companies
{
    public class CompanyHandler
    {
        private readonly CompanyManager _companyManager = new CompanyManager();
        private readonly SiteManager _siteManager = new SiteManager();
        public List<Company> GetCompanies()
        {
            return _companyManager.GetCompanies();
        }

        public void AddCompany(Company company)
        {
            _companyManager.AddCompany(company);
        }

        public void EditCompany(int companyId, CompanyViewModel companyViewModel)
        {
            _companyManager.EditCompany(companyId, companyViewModel.Company);
            _companyManager.DeleteCompanySite(companyId);
            foreach (var companySiteConnection in companyViewModel.CompanySiteConnections)
            {
                if (companySiteConnection.Selected)
                {
                    var companySite = new CompanySite() 
                    { 
                        CompanyId = companyId,
                        SiteId = companySiteConnection.SiteId
                    };
                    _companyManager.AddCompanySite(companySite);
                }
            }
        }

        public void DeleteCompany(int id)
        {
            _companyManager.DeleteCompany(id);
        }

        public Company GetCompany(int id)
        {
            return _companyManager.GetCompany(id);
        }

        public CompanyViewModel GetCompanyViewModel(int id)
        {
            var companyViewModel = new CompanyViewModel(){
                Company = _companyManager.GetCompany(id),
                CompanySiteConnections = _companyManager.GetCompanySiteConnections(id, _siteManager.GetSites())
            };
            return companyViewModel;
        }
    }
}
