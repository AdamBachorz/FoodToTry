using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Domain;
using FoodToTry.Pages;
using InfrastructureAbstractions.Entities;
using InfrastructureAbstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToTry.ViewModels
{
    public partial class MainPageViewModel : ObservableRecipient, IRecipient<Food>
    {
        private readonly IFoodRepository _foodRepository;


        [ObservableProperty]
        private ObservableCollection<Food> _openedFoods;
        [ObservableProperty]
        private ObservableCollection<Food> _closedFoods;

        public MainPageViewModel(IFoodRepository foodRepository) : base()
        {
            _foodRepository = foodRepository;
            OpenedFoods = new ObservableCollection<Food>(_foodRepository.GetFoodsByState(FoodState.Opened));
            ClosedFoods = new ObservableCollection<Food>(_foodRepository.GetFoodsByState(FoodState.Closed));
            
            Messenger.Register(this);
        }

        public void Receive(Food message)
        {
            OpenedFoods.Add(message);
        }

        [RelayCommand]
        private async Task OpenAddNewFood()
        {
            await Shell.Current.GoToAsync(nameof(AddFoodPage));
        }

        public async Task OnCheckboxChange(Food food, bool isChecked)
        {
            await Utils.InvokeIfInternetIsOn(async () =>
            {
                if (isChecked)
                {
                    food.FoodState = FoodState.Closed;
                    OpenedFoods.Remove(food);
                    ClosedFoods.Add(food);
                }
                else
                {
                    food.FoodState = FoodState.Opened;
                    OpenedFoods.Add(food);
                    ClosedFoods.Remove(food);
                }

                _foodRepository.Update(food);
            });
        }
        
    }
}
