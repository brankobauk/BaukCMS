using System.Collections.Generic;
using BaukCMS.DataLayer.Repositories;
using BaukCMS.Models.Models;

namespace BaukCMS.BusinessLogic.Companies
{
    public class CompanyManager
    {
        private readonly CompanyRepository _companyRepository = new CompanyRepository();
        public List<Company> GetCompanies()
        {
            return _companyRepository.GetCompanies();
        }

        public void AddCompany(Company company)
        {
            _companyRepository.AddCompany(company);
        }

        public void EditCompany(int id, Company company)
        {
            _companyRepository.EditCompany(id, company);
        }

        public void DeleteCompany(int id)
        {
            _companyRepository.DeleteCompany(id);
        }

        public Company GetCompany(int id)
        {
            return _companyRepository.GetCompany(id);
        }

        public List<CompanySite> GetCompanySites(int companyId)
        {
            return _companyRepository.GetCompanySites(companyId);
        }

        public List<CompanySiteConnection> GetCompanySiteConnections(int companyId, List<Site> sites)
        {
            var companySiteConnections = new List<CompanySiteConnection>();
            var companySites = GetCompanySites(companyId);
            foreach (var site in sites)
            {
                var companySiteConnection = new CompanySiteConnection();
                companySiteConnection.SiteId = site.SiteId;
                companySiteConnection.SiteName = site.Name;
                var selected = false;
                foreach (var companySite in companySites)
                { 
                    if(site.SiteId == companySite.SiteId)
                    {
                        selected = true;
                    }
                }
                companySiteConnection.Selected = selected;
                companySiteConnections.Add(companySiteConnection); 
            }
            return companySiteConnections;
        }

        public void DeleteCompanySite(int companyId)
        {
            _companyRepository.DeleteCompanySite(companyId);
        }

        public void AddCompanySite(CompanySite companySite)
        {
            _companyRepository.AddCompanySite(companySite);
        }
    }
}
