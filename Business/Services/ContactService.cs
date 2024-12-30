using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class ContactService : IContactService
{
    private readonly IFileService _fileService;
    private List<Contact> _contacts = new();

    public ContactService()
    {
        _fileService = new FileService();
    }

    public bool AddContact(Contact contact)
    {
        _contacts.Add(contact);
        _fileService.SaveListToFile(_contacts);

        return true;
    }

    public IEnumerable<Contact> GetAllContacts()
    {
        _contacts = _fileService.LoadListFromFile();
        return _contacts;
    }
}
