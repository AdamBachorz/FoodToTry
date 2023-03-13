using CommunityToolkit.Mvvm.Input;
using FoodToTry.ViewModels;
using InfrastructureAbstractions.Entities;

namespace FoodToTry;

public partial class MainPage : ContentPage
{
	public MainPageViewModel ViewModel { get; private set; }
	public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = ViewModel = vm;
	}

	private async void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var referenceObject = Utils.GetObjectFromControl<CheckBox, Food>(sender);
        await ViewModel.OnCheckboxChange(referenceObject, e.Value);
	}
}

