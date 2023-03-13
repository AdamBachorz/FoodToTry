using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
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
        private ObservableCollection<Food> _foods;

        public MainPageViewModel(IFoodRepository foodRepository) : base()
        {
            _foodRepository = foodRepository;
            Foods = new ObservableCollection<Food>(_foodRepository.GetAll());
            
            Messenger.Register(this);
        }

        public void Receive(Food message)
        {
            Foods.Add(message);
        }

        [RelayCommand]
        private async Task OpenAddNewFood()
        {
            await Shell.Current.GoToAsync(nameof(AddFoodPage));
        }

        public async Task OnCheckboxChange(Food food, bool isChecked)
        {
            await Utils.InvokeIfInternetIsOn(async() =>
            {

            });
        }
        
    }
}
