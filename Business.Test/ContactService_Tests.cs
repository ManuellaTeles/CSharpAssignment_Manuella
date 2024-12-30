using Business.Models;
using Business.Services;
using Xunit;
// Använde ChatGPT för att strukturera om koden och säkerställa att inga tester missades. Testenheter var svårt till mig ! men uppfattat iallafall !
namespace Business.Tests.Services;

public class ContactServiceTests
{
    private readonly ContactService _contactService;

    // Skapar ett nytt ContactService-objekt inför varje test.
    public ContactServiceTests()
    {
        _contactService = new ContactService();
    }

    [Fact]
    public void AddContact_ShouldAddContactSuccessfully()
    {
        // Skapa en kontakt med testinformation
        var contact = new Contact
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            PhoneNumber = "123456789",
            Address = "123 Street",
            PostalCode = "12345",
            City = "TestCity"
        };

        // Försök att lägga till kontakten
        bool result = _contactService.AddContact(contact);

        // Kontrollera att kontakten lades till (resultatet ska vara true)
        Assert.True(result);
    }

    [Fact]
    public void GetAllContacts_ShouldReturnContacts()
    {
        // Skapa och lägg till en kontakt
        var contact = new Contact
        {
            FirstName = "Alice",
            LastName = "Smith",
            Email = "alice@example.com",
            PhoneNumber = "987654321",
            Address = "456 Road",
            PostalCode = "54321",
            City = "CityA"
        };

        _contactService.AddContact(contact);

        // Hämta alla kontakter
        var contacts = _contactService.GetAllContacts();

        // Kontrollera att listan inte är null och att kontakten vi lade till finns med
        Assert.NotNull(contacts);
        Assert.Contains(contacts, c => c.Email == "alice@example.com");
    }
}
