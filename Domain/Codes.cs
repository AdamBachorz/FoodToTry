namespace Domain
{
    public static class Codes
    {
        public static readonly List<string> PopuladBrands = new() { "McDonald's", "KFC", "United Chicken", "Burger King", "Pizza Hut", "Starbucks" };
        public const string FoodItemSeparator = ";";
        public const string FoodItemInDescriptionSeparator = ", ";
        public const int MaxDescriptionLength = 20;
    }
}
