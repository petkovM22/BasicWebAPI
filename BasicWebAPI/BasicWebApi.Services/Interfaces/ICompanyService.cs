using BasicWebApi.Domain.Models;

namespace BasicWebApi.Services.Interfaces
{
    public interface ICompanyService
    {
        Company GetCompany(int companyId);
        List<Company> GetCompanies();
        int CreateCompany(Company company);
        Company UpdateCompany(int companyId, Company company);
        void DeleteCompany(int companyId);

    }
}