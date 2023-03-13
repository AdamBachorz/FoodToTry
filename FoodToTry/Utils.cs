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
        public static bool IsInternet()
        {
            return Connectivity.Current.NetworkAccess == NetworkAccess.Internet;
        }
        
        public static void InvokeIfInternetIsOn(Action action, Action actionIfNoInternet = null)
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                action();
            }
            else
            {
                if (actionIfNoInternet is null)
                {
                    Shell.Current.DisplayAlert("Uh Oh!", "No Internet", "OK");
                }
                else
                {
                    actionIfNoInternet();
                }
            }
        }

        public static T GetObjectFromControl<C, T>(object sender) where C : View where T : class
        {
            return ((C)sender).BindingContext as T;
        }
    }
}
