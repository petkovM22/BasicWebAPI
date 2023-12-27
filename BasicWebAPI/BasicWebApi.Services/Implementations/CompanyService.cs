using BasicWebApi.DataAccess;
using BasicWebApi.Domain.Models;
using BasicWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApi.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly BasicWebApiDbContext _dbContext;

        public CompanyService(BasicWebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Company GetCompany(int companyId)
        {
            return _dbContext.Companies.Find(companyId);
        }

        public List<Company> GetCompanies()
        {
            return _dbContext.Companies.ToList();
        }

        public int CreateCompany(Company company)
        {
            _dbContext.Companies.Add(company);
            _dbContext.SaveChanges();
            return company.Id;
        }

        public Company UpdateCompany(int companyId, Company company)
        {
            var existingCompany = _dbContext.Companies.Find(companyId);
            if (existingCompany != null)
            {
                existingCompany.CompanyName = company.CompanyName;
                _dbContext.SaveChanges();
            }
            return existingCompany;
        }

        public void DeleteCompany(int companyId)
        {
            var companyToDelete = _dbContext.Companies.Find(companyId);
            if (companyToDelete != null)
            {
                _dbContext.Companies.Remove(companyToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
