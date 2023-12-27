using BasicWebApi.DataAccess;
using BasicWebApi.Domain.Models;
using BasicWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApi.Services.Implementations
{
    public class ContactService : IContactService
    {
        private readonly BasicWebApiDbContext _dbContext;

        public ContactService(BasicWebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Contact GetContact(int contactId)
        {
            return _dbContext.Contacts.Find(contactId);
        }

        public List<Contact> GetContacts()
        {
            return _dbContext.Contacts.ToList();
        }

        public int CreateContact(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();
            return contact.Id;
        }

        public Contact UpdateContact(int contactId, Contact contact)
        {
            var existingContact = _dbContext.Contacts.Find(contactId);
            if (existingContact != null)
            {
                existingContact.ContactName = contact.ContactName;
                existingContact.CompanyId = contact.CompanyId;
                existingContact.CountryId = contact.CountryId;
                _dbContext.SaveChanges();
            }
            return existingContact;
        }

        public void DeleteContact(int contactId)
        {
            var contactToDelete = _dbContext.Contacts.Find(contactId);
            if (contactToDelete != null)
            {
                _dbContext.Contacts.Remove(contactToDelete);
                _dbContext.SaveChanges();
            }
        }

        public List<Contact> FilterContacts(int countryId, int companyId)
        {
            var contacts = _dbContext.Contacts.AsQueryable();

            if (countryId > 0)
            {
                contacts = contacts.Where(c => c.CountryId == countryId);
            }

            if (companyId > 0)
            {
                contacts = contacts.Where(c => c.CompanyId == companyId);
            }

            return contacts.ToList();
        }
    }
}