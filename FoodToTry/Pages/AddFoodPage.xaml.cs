using FoodToTry.ViewModels;

namespace FoodToTry.Pages;

public partial class AddFoodPage : ContentPage
{
	public AddFoodPage(AddFoodViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}