using System;
using DomainAndServices.Domain;
using DomainAndServices.Services;

namespace SortingConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var foodService = new FoodDataService();
            var foods = foodService.GetAllFoods();

            foreach (Food food in foods)
            {
                Console.WriteLine("{0}", food.Name);
            }

            Console.WriteLine("Press any key to end this program");
            Console.ReadLine();
        }
    }
}















//http://msdn.microsoft.com/en-us/library/system.icomparable(v=vs.110).aspx
