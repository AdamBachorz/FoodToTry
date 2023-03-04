using Domain;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities;

    public class Food : Entity
    {
        public string? RestaurantName { get; set; }
        public string? FoodItems { get; set; }
        public FoodState FoodState { get; set; } = FoodState.Open;
        public DateTime? CreateDate { get; set; } = DateTime.Now.Date;

        [NotMapped]
        public IList<string>? FoodItemsList => FoodItems?.Split(";")?.ToList();
        [NotMapped]
        public string FoodItemsDescription => $"({FoodItems?.Replace(";", ", ").Substring(0, 20)}...)";
    }

