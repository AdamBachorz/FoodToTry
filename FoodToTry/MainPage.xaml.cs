using CommunityToolkit.Mvvm.Input;
using FoodToTry.ViewModels;
using InfrastructureAbstractions.Entities;

namespace FoodToTry;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var t = ((CheckBox)sender).BindingContext as Food;
	}
}

