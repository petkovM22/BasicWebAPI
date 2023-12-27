using BasicWebApi.Domain.Models;
using BasicWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public ActionResult<List<Contact>> GetContacts()
        {
            try
            {
                var contacts = _contactService.GetContacts();
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{contactId}")]
        public ActionResult<Contact> GetContact(int contactId)
        {
            try
            {
                var contact = _contactService.GetContact(contactId);
                if (contact == null)
                {
                    return NotFound();
                }
                return Ok(contact);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<int> CreateContact([FromBody] Contact contact)
        {
            try
            {
                var contactId = _contactService.CreateContact(contact);
                return Ok(contactId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{contactId}")]
        public ActionResult<Contact> UpdateContact(int contactId, [FromBody] Contact contact)
        {
            try
            {
                var updatedContact = _contactService.UpdateContact(contactId, contact);
                if (updatedContact == null)
                {
                    return NotFound();
                }
                return Ok(updatedContact);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{contactId}")]
        public ActionResult DeleteContact(int contactId)
        {
            try
            {
                _contactService.DeleteContact(contactId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet("filter")]
        public ActionResult<List<Contact>> FilterContacts(int countryId, int companyId)
        {
            try
            {
                var filteredContacts = _contactService.FilterContacts(countryId, companyId);
                return Ok(filteredContacts);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
