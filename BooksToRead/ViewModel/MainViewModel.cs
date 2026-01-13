
using BooksToRead.Models;
using BooksToRead.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BooksToRead.ViewModel;
public partial class MainViewModel : ObservableObject
{
    private readonly BookDatabase _db;

    [ObservableProperty]
    ObservableCollection<Book> _books  = new();

    [ObservableProperty]
    string title;

    public MainViewModel(BookDatabase db)
    {
        _db = db;
    }

    [RelayCommand]
    async void LoadBooks()
    {
        var books = await _db.GetBooksAsync();
        Books.Clear();
        foreach (var book in books)
            Books.Add(book);
    }

    [RelayCommand]
    async Task Add()
    {
        if (string.IsNullOrWhiteSpace(Title))
            return;

        var book = new Book
        {
            Title = Title,
        };
        await _db.AddBookAsync(book);

        Books.Add(book);
        Title = string.Empty;
    }

    [RelayCommand]
    async Task Delete(Book book)
    {
        await _db.DeleteBookAsync(book);
        Books.Remove(book);
    }

    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
    }
}
