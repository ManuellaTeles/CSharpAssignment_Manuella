using Business.Models;
using Business.Services;
using Xunit;
// Använde ChatGPT för att strukturera om koden och säkerställa att inga tester missades. Testenheter var svårt till mig ! men uppfattat iallafall !
namespace Business.Tests.Services;

public class FileServiceTests
{
    private readonly FileService _fileService;
    private readonly List<Contact> _contacts;

    // Skapar ett nytt FileService-objekt och en lista med testkontakter innan varje test
    public FileServiceTests()
    {
        _fileService = new FileService("Data", "test_contacts.json");
        _contacts = new List<Contact>
        {
            new Contact
            {
                FirstName = "Test",
                LastName = "User",
                Email = "test.user@example.com",
                PhoneNumber = "1234567890",
                Address = "123 Street",
                PostalCode = "12345",
                City = "TestCity"
            }
        };
    }

    [Fact]
    public void SaveListToFile_ShouldSaveContactsSuccessfully()
    {
        // Arrange: Välj den kontakten från listan
        var expectedContact = _contacts[0];

        // Act: Spara kontakterna till fil
        _fileService.SaveListToFile(_contacts);

        // Assert: Ladda kontakterna från fil och kontrollera att de sparades korrekt
        var loadedContacts = _fileService.LoadListFromFile();
        Assert.NotNull(loadedContacts);
        Assert.Single(loadedContacts);
        Assert.Equal(expectedContact.FirstName, loadedContacts[0].FirstName);
        Assert.Equal(expectedContact.Email, loadedContacts[0].Email);
    }

    [Fact]
    public void LoadListFromFile_ShouldReturnEmptyList_WhenNoDataExists()
    {
        // Arrange: Skapa ett FileService-objekt för en tom fil och spara en tom lista
        var emptyFileService = new FileService("Data", "empty_contacts.json");
        emptyFileService.SaveListToFile(new List<Contact>());

        // Act: Ladda kontakterna från den tomma filen
        var contacts = emptyFileService.LoadListFromFile();

        // Assert: Kontrollera att listan är tom
        Assert.Empty(contacts);
    }
}
