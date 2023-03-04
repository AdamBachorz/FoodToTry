using BachorzLibrary.Common.DbModel;
using Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfrastructureAbstractions.Entities;

public class Food : Entity
{
    public string? RestaurantName { get; set; }
    public string? FoodItems { get; set; }
    public FoodState FoodState { get; set; } = FoodState.Open;
    public DateTime? CreateDate { get; set; } = DateTime.Now.Date;
    public string AdditionalInfo { get; set; } = string.Empty;

    [NotMapped]
    public IList<string>? FoodItemsList => FoodItems?.Split(";")?.ToList();
    [NotMapped]
    public string FoodItemsDescription => $"({FoodItems?.Replace(";", ", ")/*.Substring(0, 20)*/}...)";
}

