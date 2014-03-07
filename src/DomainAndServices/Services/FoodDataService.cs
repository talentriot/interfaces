using System.Collections;
using DomainAndServices.Domain;

namespace DomainAndServices.Services
{
    public class FoodDataService
    {
        public ArrayList GetAllFoods()
        {
            var apple = new Food
            {
                Id = 1,
                Name = "Apple",
                Calories = 45,
                SortOrder = 0
            };

            var tomato = new Food
            {
                Id = 2,
                Name = "Tomato",
                Calories = 30,
                SortOrder = 1
            };

            var kiwi = new Food
            {
                Id = 3,
                Name = "Kiwi",
                Calories = 1000,
                SortOrder = 2
            };

            var foods = new ArrayList
            {
                apple,
                tomato,
                kiwi
            };
            return foods;
        }
    }
}
