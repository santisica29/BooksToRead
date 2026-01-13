
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BooksToRead.ViewModel;
public partial class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
        Books = new ObservableCollection<string>();
    }

    [ObservableProperty]
    ObservableCollection<string> _books;

    [ObservableProperty]
    string text;

    [RelayCommand]
    void Add()
    {
        if (string.IsNullOrWhiteSpace(Text))
            return;

        Books.Add(Text);
        Text = string.Empty;
    }

    [RelayCommand]
    void Delete(string s)
    {
        Books.Remove(s);
    }
}
