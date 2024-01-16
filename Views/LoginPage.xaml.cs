using MauiApp2.Data;
using MauiApp2.Models;

namespace MauiApp2.Views
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void LoginBtn(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoListPage());
        }
    }
}