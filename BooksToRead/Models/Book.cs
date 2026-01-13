
using SQLite;

namespace BooksToRead.Models;

[Table("Books")]
public class Book
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Title {  get; set; }
}
