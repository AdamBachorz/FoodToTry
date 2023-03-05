using BachorzLibrary.Common.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain;
using InfrastructureAbstractions.Entities;
using InfrastructureAbstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FoodToTry.ViewModels
{
    [QueryProperty("Foods", "Foods")]
    public partial class AddFoodViewModel : ObservableObject
    {
        private readonly IFoodRepository _foodRepository;

        [ObservableProperty]
        private string newRestaurantName;
        [ObservableProperty]
        private string newFoodEntry;
        [ObservableProperty]
        private string newAdditionalInfo;
        [ObservableProperty]
        private ObservableCollection<string> newFoodItems = new();
        [ObservableProperty]
        private ObservableCollection<Food> foods;


        public AddFoodViewModel(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        [RelayCommand]
        private async Task AddFood()
        {
            var foodItem = NewFoodEntry.Trim()
                .RemoveText(Codes.FoodItemSeparator)
                .RemoveText(",")
                .RemoveText(Codes.FoodItemInDescriptionSeparator);

            if (foodItem.HasValue())
            {
                NewFoodItems.Add(foodItem);
            }
            
            NewFoodEntry = string.Empty;
        }

        [RelayCommand]
        private async Task DeleteEntry(string entry)
        {
            if (NewFoodItems.Contains(entry))
            {
                NewFoodItems.Remove(entry);
            }
        }

        [RelayCommand]
        private async Task SubmitFood()
        {
            if (NewRestaurantName.HasNotValue() || NewFoodItems.Count == 0) return;

            var food = new Food
            {
                RestaurantName = NewRestaurantName,
                FoodItems = NewFoodItems.ToList().Join(Codes.FoodItemSeparator),
                AdditionalInfo = NewAdditionalInfo ?? string.Empty
            };

            _foodRepository.Insert(food);

            await Shell.Current.GoToAsync("..");
        }
    }
}
