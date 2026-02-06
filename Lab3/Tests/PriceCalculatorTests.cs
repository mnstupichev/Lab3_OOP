using Xunit;
using FoodDelivery.Models;
using FoodDelivery.Patterns.Builder;
using FoodDelivery.Patterns.Composite;
using FoodDelivery.Patterns.Strategy;

namespace FoodDelivery.Tests
{
    public class PriceCalculatorTests
    {
        [Fact]
        public void PriceCalculator_NoDiscountNoTax_CalculatesCorrectly()
        {
            var calculator = new PriceCalculator(
                new NoDiscountStrategy(),
                new StandardDeliveryStrategy(50m),
                new NoTaxStrategy()
            );
            var order = new Order();
            order.AddItem(new MenuItemBuilder("Pizza", 500m));
            
            var total = calculator.CalculateTotal(order);
            
            Assert.Equal(550m, total);
        }

        [Fact]
        public void PriceCalculator_WithDiscount_CalculatesCorrectly()
        {
            var calculator = new PriceCalculator(
                new PercentDiscountStrategy(10m),
                new StandardDeliveryStrategy(50m),
                new NoTaxStrategy()
            );
            var order = new Order();
            order.AddItem(new MenuItemBuilder("Pizza", 1000m));
            
            var total = calculator.CalculateTotal(order);
            
            Assert.Equal(950m, total);
        }

        [Fact]
        public void PriceCalculator_WithTax_CalculatesCorrectly()
        {
            var calculator = new PriceCalculator(
                new NoDiscountStrategy(),
                new StandardDeliveryStrategy(50m),
                new TaxStrategy(10m)
            );
            var order = new Order();
            order.AddItem(new MenuItemBuilder("Pizza", 1000m));
            
            var total = calculator.CalculateTotal(order);
            
            Assert.Equal(1150m, total);
        }

        [Fact]
        public void PriceCalculator_WithDiscountAndTax_CalculatesCorrectly()
        {
            var calculator = new PriceCalculator(
                new PercentDiscountStrategy(20m),
                new StandardDeliveryStrategy(100m),
                new TaxStrategy(10m)
            );
            var order = new Order();
            order.AddItem(new MenuItemBuilder("Pizza", 1000m));
            
            var total = calculator.CalculateTotal(order);
            
            Assert.Equal(980m, total);
        }

        [Fact]
        public void PriceCalculator_FreeDelivery_CalculatesCorrectly()
        {
            var calculator = new PriceCalculator(
                new NoDiscountStrategy(),
                new FreeDeliveryStrategy(1000m),
                new NoTaxStrategy()
            );
            var order = new Order();
            order.AddItem(new MenuItemBuilder("Pizza", 1500m));
            
            var total = calculator.CalculateTotal(order);
            
            Assert.Equal(1500m, total);
        }

        [Fact]
        public void PriceCalculator_ExpressDelivery_CalculatesCorrectly()
        {
            var calculator = new PriceCalculator(
                new NoDiscountStrategy(),
                new ExpressDeliveryStrategy(200m),
                new NoTaxStrategy()
            );
            var order = new Order();
            order.AddItem(new MenuItemBuilder("Burger", 500m));
            
            var total = calculator.CalculateTotal(order);
            
            Assert.Equal(700m, total);
        }

        [Fact]
        public void PriceCalculator_MultipleItems_CalculatesCorrectly()
        {
            var calculator = new PriceCalculator(
                new PercentDiscountStrategy(10m),
                new StandardDeliveryStrategy(50m),
                new TaxStrategy(20m)
            );
            var order = new Order();
            order.AddItem(new MenuItemBuilder("Pizza", 500m));
            order.AddItem(new MenuItemBuilder("Burger", 300m));
            order.AddItem(new MenuItemBuilder("Cola", 100m));
            
            var total = calculator.CalculateTotal(order);
            
            Assert.Equal(860m, total);
        }

        [Fact]
        public void PriceCalculator_ComplexScenario_CalculatesCorrectly()
        {
            var calculator = new PriceCalculator(
                new PercentDiscountStrategy(15m),
                new StandardDeliveryStrategy(75m),
                new TaxStrategy(5m)
            );
            var order = new Order();
            order.AddItem(new MenuItemBuilder("Item1", 1000m));
            order.AddItem(new MenuItemBuilder("Item2", 500m));
            
            var total = calculator.CalculateTotal(order);
            
            Assert.Equal(1416.25m, total);
        }
    }
}
