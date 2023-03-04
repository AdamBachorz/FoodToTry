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

}

