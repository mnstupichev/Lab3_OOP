using Lab3.Menu;
using Lab3.Menu.MenuItems;
using Lab3.PriceCalculator.Delivery;
using Lab3.PriceCalculator.Discount;
using Lab3.PriceCalculator.Taxes;

namespace Lab3.Tests;

public class PriceCalculatorTests
{
    [Fact]
    public void PriceCalculator_NoDiscountNoTax_StandardDelivery_CalculatesCorrectly()
    {
        var calculator = new PriceCalculator.PriceCalculator(
            new NoDiscountStrategy(),
            new StandartDeliveryStrategy(50),
            new NoTaxStrategy()
        );
        var items = new List<IMenuItem>
        {
            new Potato()
        };
        var order = new Order.Order("Street", false, items);
        
        var total = calculator.CalculateTotal(order);
        
        Assert.Equal(150, total);
    }

    [Fact]
    public void PriceCalculator_WithDiscount_CalculatesCorrectly()
    {
        var calculator = new PriceCalculator.PriceCalculator(
            new PercentDiscountStrategy(10),
            new StandartDeliveryStrategy(50),
            new NoTaxStrategy()
        );
        var items = new List<IMenuItem>
        {
            new Potato()
        };
        var order = new Order.Order("Street", false, items);
        
        var total = calculator.CalculateTotal(order);

        Assert.Equal(140, total);
    }

    [Fact]
    public void PriceCalculator_WithTax_CalculatesCorrectly()
    {
        var calculator = new PriceCalculator.PriceCalculator(
            new NoDiscountStrategy(),
            new StandartDeliveryStrategy(50),
            new TaxStrategy(10)
        );
        var items = new List<IMenuItem>
        {
            new Potato()
        };
        var order = new Order.Order("Street", false, items);
        
        var total = calculator.CalculateTotal(order);

        Assert.Equal(160, total);
    }

    [Fact]
    public void PriceCalculator_WithDiscountAndTax_CalculatesCorrectly()
    {
        var calculator = new PriceCalculator.PriceCalculator(
            new PercentDiscountStrategy(10),
            new StandartDeliveryStrategy(50),
            new TaxStrategy(10)
        );
        var items = new List<IMenuItem>
        {
            new Potato()
        };
        var order = new Order.Order("Street", false, items);
        
        var total = calculator.CalculateTotal(order);
        
        Assert.Equal(149, total);
    }

    [Fact]
    public void PriceCalculator_FreeDeliveryAboveThreshold_CalculatesCorrectly()
    {
        var calculator = new PriceCalculator.PriceCalculator(
            new NoDiscountStrategy(),
            new FreeDeliveryStrategy(),
            new NoTaxStrategy()
        );
        var items = new List<IMenuItem>
        {
            new Pizza()
        };
        var order = new Order.Order("Street", false, items);
        
        var total = calculator.CalculateTotal(order);

        Assert.Equal(1000, total);
    }
    
    [Fact]
    public void PriceCalculator_MultipleItems_CalculatesCorrectly()
    {
        var calculator = new PriceCalculator.PriceCalculator(
            new NoDiscountStrategy(),
            new StandartDeliveryStrategy(50),
            new NoTaxStrategy()
        );
        var items = new List<IMenuItem>
        {
            new Potato(),
            new Potato(),
            new Pizza()
        };
        var order = new Order.Order("Street", false, items);
        
        var total = calculator.CalculateTotal(order);

        Assert.Equal(1200, total);
    }
}
