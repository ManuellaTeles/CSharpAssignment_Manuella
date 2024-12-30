using Business.Interfaces;
using Business.Models;
using System.Text.Json;

namespace Business.Services;

public class FileService : IFileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;

    public FileService(string directoryPath = "Data", string fileName = "contacts.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(directoryPath, fileName);
    }

    public void SaveListToFile(List<Contact> list)
    {
        try
        {
            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);

            var json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Oops! Something went wrong: {ex.Message}");
        }
    }

    public List<Contact> LoadListFromFile()
    {
        try
        {
            if (!File.Exists(_filePath)) return new List<Contact>();

            var json = File.ReadAllText(_filePath);
            var list = JsonSerializer.Deserialize<List<Contact>>(json);
            return list ?? new List<Contact>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Oops! Something went wrong: {ex.Message}");
            return new List<Contact>();
        }
    }
}
