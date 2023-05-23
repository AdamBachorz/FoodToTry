using BachorzLibrary.Common.DbModel;
using Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfrastructureAbstractions.Entities;

public class Restaurant : Entity
{
    public string Name { get; set; }
    public string FoodItems { get; set; }
    public State State { get; set; } = State.Opened;
    public DateTime? CreateDate { get; set; } = DateTime.Now.Date;
    public string AdditionalInfo { get; set; } = string.Empty;

    [NotMapped]
    public IList<string>? FoodItemsList => FoodItems.Split(Codes.FoodItemSeparator)?.ToList();
    [NotMapped]
    public string FoodItemsDescription => CreateFoodItemsDescription();

    private string CreateFoodItemsDescription()
    {
        var description = FoodItems.Replace(Codes.FoodItemSeparator, Codes.FoodItemInDescriptionSeparator);

        return description.Length >= Codes.MaxDescriptionLength - 2 ? $"({description.Substring(0, Codes.MaxDescriptionLength)}...)" : $"({description})";
    }
}

