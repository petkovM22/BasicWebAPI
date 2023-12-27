using BasicWebApi.Domain.Models;

namespace BasicWebApi.Services.Interfaces
{
    public interface IContactService
    {
        Contact GetContact(int contactId);
        List<Contact> GetContacts();
        int CreateContact(Contact contact);
        Contact UpdateContact(int contactId, Contact contact);
        void DeleteContact(int contactId);
        List<Contact> FilterContacts(int countryId, int companyId);

    }
}