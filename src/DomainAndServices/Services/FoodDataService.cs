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
                SortNum = 9,
                Name = "Apple",
                Calories = 45
            };

            var tomato = new Food
            {
                Id = 2,
                SortNum = 7,
                Name = "Tomato",
                Calories = 30
            };

            var kiwi = new Food
            {
                Id = 3,
                SortNum = 3,
                Name = "Kiwi",
                Calories = 1000
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
