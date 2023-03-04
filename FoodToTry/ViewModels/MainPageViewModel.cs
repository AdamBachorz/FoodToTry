using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly IFoodRepository _foodRepository;


        [ObservableProperty]
        private ObservableCollection<Food> foodItems;

        public MainPageViewModel(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
            FoodItems = new ObservableCollection<Food>(_foodRepository.GetAll());
        }


        [RelayCommand]
        private async Task OpenAddNewFood()
        {
            await Shell.Current.GoToAsync(nameof(AddFoodPage));
        }
        
    }
}
