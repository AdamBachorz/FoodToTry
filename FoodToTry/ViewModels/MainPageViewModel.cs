using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Domain;
using FoodToTry.Pages;
using InfrastructureAbstractions.Entities;
using InfrastructureAbstractions.Repositories;
using System.Collections.ObjectModel;

namespace FoodToTry.ViewModels
{
    public partial class MainPageViewModel : ObservableRecipient, IRecipient<Restaurant>
    {
        private readonly IFoodRepository _foodRepository;


        [ObservableProperty]
        private ObservableCollection<Restaurant> _restaurants;

        public MainPageViewModel(IFoodRepository foodRepository) : base()
        {
            _foodRepository = foodRepository;
            var restaurants = _foodRepository.GetOrderedRestaurants();
            Restaurants = new ObservableCollection<Restaurant>(restaurants);
            
            Messenger.Register(this);
        }

        public void Receive(Restaurant message)
        {
            Restaurants.Add(message);
        }

        [RelayCommand]
        private async Task OpenAddNewFood()
        {
            await Shell.Current.GoToAsync(nameof(AddFoodPage));
        }

        public async Task OnCheckboxChange(Restaurant restaurant, bool isChecked)
        {
            await Utils.InvokeIfInternetIsOn(() =>
            {
                restaurant.State = isChecked ? State.Closed : State.Opened;
                _foodRepository.Update(restaurant);
            });
        }
        
    }
}
