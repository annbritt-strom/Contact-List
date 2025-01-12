using Business.Dtos;
using Business.Factories;
using Business.Models;

namespace Tests.FactoryTests;
public class UserFactory_Tests
{
    [Fact]
    public void ShouldReturnContact_WhenContactRegistrationFormIsProvided()
    {
        // Arrange
        var ContactRegistrationForm = new ContactRegistrationForm()
        {
            FirstName = "Test",
            LastName = "Name",
            Email = "test@email.com",
            PhoneNumber = "1234567890",
            Address = "12-34 Street City, Country"
        };

        // Act
        var result = ContactFactory.Create(ContactRegistrationForm);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<ContactModel>(result);
        Assert.Equal(ContactRegistrationForm.FirstName, result.FirstName);
        Assert.Equal(ContactRegistrationForm.LastName, result.LastName);
        Assert.Equal(ContactRegistrationForm.Email, result.Email);
        Assert.Equal(ContactRegistrationForm.PhoneNumber, result.PhoneNumber);
        Assert.Equal(ContactRegistrationForm.Address, result.Address);
    }

    [Fact]
    public void ShouldReturnContactRegistrationForm()
    {
        // Act
        var result = ContactFactory.Create();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<ContactRegistrationForm>(result);
    }
}
