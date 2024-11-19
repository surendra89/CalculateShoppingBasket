using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateShoppingBasket.Services
{
    public class BasketPricingService
    {
        private readonly Dictionary<string, decimal> _prices;

        // Constructor to initialize prices
        public BasketPricingService()
        {
            _prices = new Dictionary<string, decimal>
            {
                { "Apple", 0.35m },
                { "Banana", 0.20m },
                { "Melon", 0.50m },
                { "Lime", 0.15m }
            };
        }
        public decimal CalculateTotal(List<string> shoppingList)
        {
            // Dictionary to store the count of items in the shopping list
            var itemCounts = new Dictionary<string, int>();

            // Count occurrences of each item in the shopping list
            foreach (var item in shoppingList)
            {
                itemCounts[item] = itemCounts.GetValueOrDefault(item) + 1;
            }

            // Variable to hold the total cost
            decimal totalCost = 0m;

            // Calculate the cost for each item type
            foreach (var item in itemCounts)
            {
                string itemName = item.Key;
                int count = item.Value;

                switch (itemName)
                {
                    case "Apple":
                        totalCost += count * _prices["Apple"];
                        break;

                    case "Banana":
                        totalCost += count * _prices["Banana"];
                        break;

                    case "Melon":
                        // Melons: Buy 1 get 1 free (for every 2 melons, you pay for 1)
                        totalCost += (count / 2) * _prices["Melon"] + (count % 2) * _prices["Melon"];
                        break;

                    case "Lime":
                        // Limes: Three for the price of two (for every 3 limes, you pay for 2)
                        totalCost += (count / 3) * 2 * _prices["Lime"] + (count % 3) * _prices["Lime"];
                        break;

                    default:
                        throw new ArgumentException($"Unknown item: {itemName}");
                }
            }

            return totalCost;
        }
    }
}
