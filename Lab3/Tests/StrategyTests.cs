using Lab3.PriceCalculator.Delivery;
using Lab3.PriceCalculator.Discount;
using Lab3.PriceCalculator.Taxes;

namespace Lab3.Tests;

public class StrategyTests
{
    [Fact]
    public void NoDiscountStrategy_CalculateDiscount_ReturnsZero()
    {
        var strategy = new NoDiscountStrategy();
            
        var discount = strategy.CalculateDiscount(1000m);
            
        Assert.Equal(0m, discount);
    }

    [Fact]
    public void PercentDiscountStrategy_CalculateDiscount_CalculatesCorrectly()
    {
        var strategy = new PercentDiscountStrategy(10m);
            
        var discount = strategy.CalculateDiscount(1000m);
            
        Assert.Equal(100m, discount);
    }

    [Fact]
    public void PercentDiscountStrategy_CalculateDiscount_25Percent()
    {
        var strategy = new PercentDiscountStrategy(25m);
            
        var discount = strategy.CalculateDiscount(800m);
            
        Assert.Equal(200m, discount);
    }

    [Fact]
    public void StandardDeliveryStrategy_CalculateDeliveryCost_ReturnsFixedCost()
    {
        var strategy = new StandardDeliveryStrategy(50m);
            
        var cost = strategy.CalculateDeliveryCost(1000m);
            
        Assert.Equal(50m, cost);
    }

    [Fact]
    public void ExpressDeliveryStrategy_CalculateDeliveryCost_ReturnsFixedCost()
    {
        var strategy = new StandartDeliveryStrategy(100m);
            
        var cost = strategy.CalculateDeliveryCost(500m);
            
        Assert.Equal(100m, cost);
    }

    [Fact]
    public void FreeDeliveryStrategy_BelowThreshold_ReturnsFree()
    {
        var strategy = new FreeDeliveryStrategy(1000m);
            
        var cost = strategy.CalculateDeliveryCost(500m);
            
        Assert.Equal(0m, cost);
    }

    [Fact]
    public void FreeDeliveryStrategy_AboveThreshold_ReturnsFree()
    {
        var strategy = new FreeDeliveryStrategy(1000m);
            
        var cost = strategy.CalculateDeliveryCost(1500m);
            
        Assert.Equal(0m, cost);
    }

    [Fact]
    public void NoTaxStrategy_CalculateTax_ReturnsZero()
    {
        var strategy = new NoTaxStrategy();
            
        var tax = strategy.CalculateTax(1000m);
            
        Assert.Equal(0m, tax);
    }

    [Fact]
    public void TaxStrategy_CalculateTax_DefaultRate()
    {
        var strategy = new TaxStrategy();
            
        var tax = strategy.CalculateTax(1000m);
            
        Assert.Equal(200m, tax);
    }

    [Fact]
    public void TaxStrategy_CalculateTax_CustomRate()
    {
        var strategy = new TaxStrategy(10m);
            
        var tax = strategy.CalculateTax(1000m);
            
        Assert.Equal(100m, tax);
    }

    [Fact]
    public void TaxStrategy_CalculateTax_5PercentRate()
    {
        var strategy = new TaxStrategy(5m);
            
        var tax = strategy.CalculateTax(2000m);
            
        Assert.Equal(100m, tax);
    }
}