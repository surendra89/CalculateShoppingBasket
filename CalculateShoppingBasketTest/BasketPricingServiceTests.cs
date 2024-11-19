using CalculateShoppingBasket.Services;
namespace CalculateShoppingBasketTest
{
    public class BasketPricingServiceTests
    {
        private readonly BasketPricingService _pricingService;

        public BasketPricingServiceTests()
        {
            _pricingService = new BasketPricingService();
        }
        [Fact]
        public void CalculateTotal_ShouldReturnCorrectPrice_ForSimpleBasket()
        {
            // Arrange
            var shoppingList = new List<string> { "Apple", "Apple", "Banana" };

            // Act
            decimal totalCost = _pricingService.CalculateTotal(shoppingList);

            // Assert
            Assert.Equal(0.90m, totalCost);  // 2 apples (2 * 0.35) + 1 banana (1 * 0.20)
        }
        [Fact]
        public void CalculateTotal_ShouldApplyMelonOfferCorrectly()
        {
            // Arrange
            var shoppingList = new List<string> { "Melon", "Melon", "Melon", "Melon" };

            // Act
            decimal totalCost = _pricingService.CalculateTotal(shoppingList);

            // Assert
            Assert.Equal(1.00m, totalCost);  // 4 melons -> pay for 2 (2 * 0.50)
        }
        [Fact]
        public void CalculateTotal_ShouldApplyLimeOfferCorrectly()
        {
            // Arrange
            var shoppingList = new List<string> { "Lime", "Lime", "Lime", "Lime", "Lime" };

            // Act
            decimal totalCost = _pricingService.CalculateTotal(shoppingList);

            // Assert
            Assert.Equal(0.45m, totalCost);  // 5 limes -> pay for 4 (2 * 0.15 + 2 * 0.15)
        }

        [Fact]
        public void CalculateTotal_ShouldThrowException_ForUnknownItem()
        {
            // Arrange
            var shoppingList = new List<string> { "Apple", "Banana", "UnknownItem" };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _pricingService.CalculateTotal(shoppingList));
        }
    }
}