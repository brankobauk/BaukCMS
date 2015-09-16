using System.Collections.Generic;
using System.Linq;
using BaukCMS.DataLayer.Context;
using BaukCMS.Models.Models;

namespace BaukCMS.DataLayer.Repositories
{
    public class CompanyRepository
    {
        private readonly BaukCMSContext _db = new BaukCMSContext();

        public List<Company> GetCompanies()
        {
            return _db.Company.ToList();
        }

        public void AddCompany(Company company)
        {
            _db.Company.Add(company);
            _db.SaveChanges();
        }

        public void EditCompany(int id, Company company)
        {
            var companyToEdit = GetCompany(id);
            if (companyToEdit == null) return;
            companyToEdit.Name = company.Name;
            _db.SaveChanges();
        }

        public void DeleteCompany(int id)
        {
            var companyToDelete = GetCompany(id);
            _db.Company.Remove(companyToDelete);
            _db.SaveChanges();
        }

        public Company GetCompany(int id)
        {
            return _db.Company.FirstOrDefault(p => p.CompanyId == id);
        }

        public List<CompanySite> GetCompanySites(int companyId)
        {
            return _db.CompanySite.Where(p => p.CompanyId == companyId).ToList();
        }

        public void DeleteCompanySite(int companyId)
        {
            var companySiteToDelete = _db.CompanySite.Where(p=>p.CompanyId == companyId).ToList();
            _db.CompanySite.RemoveRange(companySiteToDelete);
            _db.SaveChanges();
        }

        public void AddCompanySite(CompanySite companySite)
        {
            _db.CompanySite.Add(companySite);
            _db.SaveChanges();
        }
    }
}
