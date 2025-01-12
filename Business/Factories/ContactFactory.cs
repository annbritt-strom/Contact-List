using Business.Dtos;
using Business.Models;
using Business.Services;

namespace Business.Factories;

public static class ContactFactory
{
    public static ContactRegistrationForm Create() => new();

    public static ContactModel Create(ContactRegistrationForm form) => new() 
    {
        FirstName = form.FirstName,
        LastName = form.LastName,
        Email = form.Email,
        PhoneNumber = form.PhoneNumber,
        Address = form.Address,
        ID = GuidGeneratorService.Generate()
    };

}
