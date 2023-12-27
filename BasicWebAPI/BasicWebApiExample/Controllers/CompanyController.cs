using BasicWebApi.Domain.Models;
using BasicWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public ActionResult<List<Company>> GetCompanies()
        {
            try
            {
                var companies = _companyService.GetCompanies();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{companyId}")]
        public ActionResult<Company> GetCompany(int companyId)
        {
            try
            {
                var company = _companyService.GetCompany(companyId);
                if (company == null)
                {
                    return NotFound();
                }
                return Ok(company);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<int> CreateCompany([FromBody] Company company)
        {
            try
            {
                var companyId = _companyService.CreateCompany(company);
                return Ok(companyId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{companyId}")]
        public ActionResult<Company> UpdateCompany(int companyId, [FromBody] Company company)
        {
            try
            {
                var updatedCompany = _companyService.UpdateCompany(companyId, company);
                if (updatedCompany == null)
                {
                    return NotFound();
                }
                return Ok(updatedCompany);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{companyId}")]
        public ActionResult DeleteCompany(int companyId)
        {
            try
            {
                _companyService.DeleteCompany(companyId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}