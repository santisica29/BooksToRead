
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BooksToRead.ViewModel;
public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<string> _books  = new();

    [ObservableProperty]
    string text;

    public MainViewModel()
    {
  
    }

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

    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
    }
}
