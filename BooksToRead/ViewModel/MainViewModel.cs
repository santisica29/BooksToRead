
using BooksToRead.Models;
using BooksToRead.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BooksToRead.ViewModel;
public partial class MainViewModel : ObservableObject
{
    private readonly BookApiService _apiService;

    public ObservableCollection<Book> BooksFromAPI { get; } = new();

    [ObservableProperty]
    string title;

    [ObservableProperty]
    string description;

    public MainViewModel()
    {
        _apiService = new BookApiService();
        _ = LoadBooksAsync();
    }

    private async Task LoadBooksAsync()
    {
        var books = await _apiService.GetBooksAsync();

        BooksFromAPI.Clear();
        foreach (var book in books)
            BooksFromAPI.Add(book);
    }

    [RelayCommand]
    async Task Add()
    {
        if (string.IsNullOrWhiteSpace(Title))
            return;

        var newBook = new Book
        {
            Title = Title,
            Description = Description
        };

        var createdBook = await _apiService.CreateBookAsync(newBook);

        if (createdBook is null)
            return;

        BooksFromAPI.Add(newBook);

        Title = string.Empty;
        Description = string.Empty;
    }

    [RelayCommand]
    void Delete(Book book)
    {
        BooksFromAPI.Remove(book);
    }

    [RelayCommand]
    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
    }
}
