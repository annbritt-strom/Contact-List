using System.Text.Json;
using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class ContactService(IFileService fileService) : IContactService
{
    private readonly IFileService _fileService = fileService;
    private List<ContactModel> _contacts = [];

    public IEnumerable<ContactModel> GetAll()
    {
        var data = _fileService.GetContentFromFile();

        try
        {
            _contacts = JsonSerializer.Deserialize<List<ContactModel>>(data)!;
        }

        catch
        {
            _contacts = [];
        }

        return _contacts;
    }

    public bool SaveContact(ContactRegistrationForm form)
    {
        var contact = ContactFactory.Create(form);
        _contacts.Add(contact);
        
        var json = JsonSerializer.Serialize(_contacts);
        var result = _fileService.SaveToFile(json);
        return result;
    }
}
