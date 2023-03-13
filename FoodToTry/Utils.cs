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
        public static T GetObjectFromControl<C, T>(object sender) where C : View where T : class
        {
            return ((C)sender).BindingContext as T;
        }
    }
}
