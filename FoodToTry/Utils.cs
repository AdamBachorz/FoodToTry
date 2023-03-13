using InfrastructureAbstractions.Entities;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToTry
{
    public static class Utils
    {
        public static async Task GoBack() => await Shell.Current.GoToAsync("..");
        public static bool IsInternet() => Connectivity.Current.NetworkAccess == NetworkAccess.Internet;

        public static async Task InvokeIfInternetIsOn(Action action, Action actionIfNoInternet = null)
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                action();
            }
            else
            {
                if (actionIfNoInternet is null)
                {
                    await Shell.Current.DisplayAlert("Uh Oh!", "No Internet", "OK");
                }
                else
                {
                    actionIfNoInternet();
                }
            }
        }

        public static T GetObjectFromControl<C, T>(object sender) where C : View where T : class => ((C)sender).BindingContext as T;
    }
}
