using System;
using System.Collections.Generic;
using CalculateShoppingBasket.Services;

namespace ShoppingBasketApp
{
    class Program
    {
        static void Main()
        {
            // Sample shopping list
            List<string> shoppingList = new List<string>
            {
                "Apple", "Apple", "Banana", "Melon", "Melon", "Lime", "Lime", "Lime"
            };

            // Create a service instance
            var pricingService = new BasketPricingService();

            // Calculate total cost
            decimal totalCost = pricingService.CalculateTotal(shoppingList);

            // Output the result
            Console.WriteLine($"Total cost of the basket: £{totalCost:F2}");
        }
    }
}
