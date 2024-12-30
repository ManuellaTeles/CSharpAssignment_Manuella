using Business.Interfaces;
using Business.Models;
using Business.Services;

namespace MainApp.Dialogs;

public class ContactMenu
{
    private readonly IContactService _contactService;

    public ContactMenu()
    {
        _contactService = new ContactService();
    }

    public void ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Inlämningsuppgift C#");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("1. Contacts List");
            Console.WriteLine("");
            Console.WriteLine("2. Create a New Contact");
            Console.WriteLine("");
            Console.WriteLine("3. Exit");
            Console.WriteLine("--------------------------------------------");

            string option = Console.ReadLine()?.Trim() ?? string.Empty;

            switch (option)
            {
                case "1":
                    ListContacts();
                    break;
                case "2":
                    CreateContact();
                    break;
                case "3":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Error, Choose one of the following options only!");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private void ListContacts()
    {
        Console.Clear();
        Console.WriteLine("List of Contacts:");
        Console.WriteLine("---------------------------");

        var contacts = _contactService.GetAllContacts();

        if (!contacts.Any())
        {
            Console.WriteLine("No contacts found.");
        }
        else
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine($"Phone: {contact.PhoneNumber}");
                Console.WriteLine($"Address: {contact.Address}");
                Console.WriteLine($"Postal Code: {contact.PostalCode}");
                Console.WriteLine($"City: {contact.City}");
                Console.WriteLine("---------------------------");
            }
        }

        Console.WriteLine("Press any key to return to the main menu :)");
        Console.ReadKey();
    }

    private void CreateContact()
    {
        Console.Clear();
        Console.WriteLine("Creating a New Contact");
        Console.WriteLine("---------------------------------------");

        string firstName;
        do
        {
            Console.Write("Write Your *First Name* Here Please, It's Is A Must:");
            firstName = Console.ReadLine()?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(firstName))
                Console.WriteLine("First Name cannot be empty. Please try again.");
        } while (string.IsNullOrEmpty(firstName));

        string lastName;
        do
        {
            Console.Write("Write Your *Last Name* Here Please, It's Is A Must:");
            lastName = Console.ReadLine()?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(lastName))
                Console.WriteLine("Last Name cannot be empty. Please try again.");
        } while (string.IsNullOrEmpty(lastName));

        string email;
        do
        {
            Console.Write("Write Your *Email* Here Please, It's Is A Must:");
            email = Console.ReadLine()?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(email))
                Console.WriteLine("Email cannot be empty. Please try again.");
        } while (string.IsNullOrEmpty(email));


        string phoneNumber;
        do
        {
            Console.Write("Write Your *Phone Number* Here Please, It's Is A Must: ");
            phoneNumber = Console.ReadLine()?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(phoneNumber))
                Console.WriteLine("Phone Number cannot be empty. Please try again.");
        } while (string.IsNullOrEmpty(phoneNumber));

        string address;
        do
        {
            Console.Write("Write Your *Address* Here Please, It's Is A Must:");
            address = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrEmpty(address))
                Console.WriteLine("Address cannot be empty. Please try again.");
        } while (string.IsNullOrEmpty(address));

        string postalCode;
        do
        {
            Console.Write("Write Your *Postal Code* Here Please, It's Is A Must:");
            postalCode = Console.ReadLine()?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(postalCode))
                Console.WriteLine("Postal Code cannot be empty. Please try again.");
        } while (string.IsNullOrEmpty(postalCode));

        string city;
        do
        {
            Console.Write("Write Your *City* Here Please, It's Is A Must:");
            city = Console.ReadLine()?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(city))
                Console.WriteLine("City cannot be empty. Please try again.");
        } while (string.IsNullOrEmpty(city));

        var contact = new Contact
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber,
            Address = address,
            PostalCode = postalCode,
            City = city
        };


        bool success = _contactService.AddContact(contact);

        if (success)
        {
            Console.WriteLine($"Your ID is: {contact.ContactId}");
        }
        else
        {
            Console.WriteLine("Failed");
        }

        Console.ReadKey();
    }
}
