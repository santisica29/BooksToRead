using BooksToRead.Models;
using System.Text;
using System.Text.Json;

namespace BooksToRead.Services;

public class BookApiService
{
    private readonly HttpClient _httpClient;

    public BookApiService()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://openlibrary.org/subjects/classics.json?limit=5")
        };
    }

    public async Task<List<Book>?> GetBooksAsync()
    {
        var response = await _httpClient.GetAsync("todos");

        if (!response.IsSuccessStatusCode)
            return new List<Book>();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<List<Book>>(json);
    }

    public async Task<Book?> CreateBookAsync(Book newBook)
    {
        var json = JsonSerializer.Serialize(newBook);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("books", content);

        if (!response.IsSuccessStatusCode)
            return null;

        var responseJson = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<Book>(responseJson);
    }
}
