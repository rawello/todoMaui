using MauiApp2.Views;
using MauiApp2.Models;
namespace MauiApp2;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		
		MainPage = new NavigationPage(new LoginPage())
		{
			BarTextColor = Color.FromRgb(255, 255, 255)
		};
	}
}
