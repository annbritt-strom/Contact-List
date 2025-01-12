using Business.Dtos;
using Business.Models;

namespace Business.Interfaces;

public interface IContactService
{
    bool SaveContact(ContactRegistrationForm form);

    IEnumerable<ContactModel> GetAll();
}
