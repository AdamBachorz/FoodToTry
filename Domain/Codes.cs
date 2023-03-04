using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class Codes
    {
        public static readonly List<string> PopuladBrands = new() { "McDonald's", "KFC", "United Chicken", "Burger King", "Pizza Hut", "Starbucks" };
        public const string FoodItemSeparator = ";";
        public const string FoodItemInDescriptionSeparator = ", ";
    }
}
