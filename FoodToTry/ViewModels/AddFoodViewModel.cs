using BachorzLibrary.Common.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Domain;
using InfrastructureAbstractions.Entities;
using InfrastructureAbstractions.Repositories;
using System.Collections.ObjectModel;

namespace FoodToTry.ViewModels
{
    public partial class AddFoodViewModel : ObservableRecipient
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


        public AddFoodViewModel(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        [RelayCommand]
        private void AddFood()
        {
            if (NewFoodEntry.Contains(","))
            {
                var foodItems = NewFoodEntry.Trim()
                    .Split(",")
                    .Select(x => x.Trim())
                    .WithoutEmptyValues();

                if (foodItems.IsNotNullOrEmpty())
                {
                    foodItems.ForEach(fi => NewFoodItems.Add(fi));
                }
            }
            else
            {
                var foodItem = NewFoodEntry.Trim()
                    .RemoveText(Codes.FoodItemSeparator)
                    .RemoveText(",")
                    .RemoveText(Codes.FoodItemInDescriptionSeparator);

                if (foodItem.HasValue())
                {
                    NewFoodItems.Add(foodItem);
                }
            }

            NewFoodEntry = string.Empty;
        }

        [RelayCommand]
        private void DeleteEntry(string entry)
        {
            if (NewFoodItems.Contains(entry))
            {
                NewFoodItems.Remove(entry);
            }
        }

        [RelayCommand]
        private async Task SubmitFood()
        {
            await Utils.InvokeIfInternetIsOn(async () =>
            {
                if (NewRestaurantName.HasNotValue() || NewFoodItems.Count == 0) return;

                var restaurnat = _foodRepository.Insert(new Restaurant
                {
                    Name = NewRestaurantName,
                    FoodItems = NewFoodItems.ToList().Join(Codes.FoodItemSeparator),
                    AdditionalInfo = NewAdditionalInfo ?? string.Empty
                });

                Messenger.Send(restaurnat);
                await Utils.GoBack();
            });
        }
    }
}
