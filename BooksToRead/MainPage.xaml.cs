using BooksToRead.ViewModel;

namespace BooksToRead;
public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();

        // one way of binding
        //BindingContext = new MainViewModel();
        BindingContext = vm;
    }
}
