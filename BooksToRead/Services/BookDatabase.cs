using SQLite;
using BooksToRead.Models;

namespace BooksToRead.Services;

public class BookDatabase
{
    private readonly SQLiteAsyncConnection _database;

    public BookDatabase(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Book>().Wait(); // Create table if it doesn't exist
    }

    public Task<List<Book>> GetBooksAsync() =>
        _database.Table<Book>().ToListAsync();

    public Task<int> AddBookAsync(Book book) =>
        _database.InsertAsync(book);

    public Task<int> DeleteBookAsync(Book book) =>
        _database.DeleteAsync(book);
}
