namespace Lab3.PriceCalculator.Discount;

public class NoDiscountStrategy : IDiscountStrategy
{
    public decimal CalculateDiscount(decimal amount)
    {
        return 0;
    }
}

