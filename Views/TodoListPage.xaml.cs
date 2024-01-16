using MauiApp2.Data;
using MauiApp2.Models;
using MauiApp2.Views;

namespace MauiApp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoListPage : ContentPage
    {
        public TodoListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            TodoItemDatabase database = await TodoItemDatabase.Instance;
            collectionView.ItemsSource = await database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = new TodoItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TodoItemPage
                {
                    BindingContext = e.SelectedItem as TodoItem
                });
            }
        }
        
        async void SwipeView_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            if (e.SwipeDirection == SwipeDirection.Left)
            {
                var selectedItem = (sender as SwipeView).BindingContext as TodoItem;
                if (selectedItem != null)
                {
                    Navigation.PushAsync(new TodoItemPage
                    {
                        BindingContext = selectedItem
                    });
                }
            }
            else
            {
                var selectedItem = (sender as SwipeView).BindingContext as TodoItem;
                if (selectedItem != null)
                {
                    TodoItemDatabase database = await TodoItemDatabase.Instance;
                    selectedItem.Done = !selectedItem.Done;
                    await database.SaveItemAsync(selectedItem);
                    collectionView.ItemsSource = await database.GetItemsAsync();
                }
            }
        }
        
        async void LogoutBtn(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Logout", "Are you sure you want to logout?", "Yes", "No");

            if (answer)
            {
                //такие дела
                Navigation.PushAsync(new LoginPage());
            }
        }
    }
}