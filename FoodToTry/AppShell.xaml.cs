using FoodToTry.Pages;

namespace FoodToTry;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(AddFoodPage), typeof(AddFoodPage));
    }
}
