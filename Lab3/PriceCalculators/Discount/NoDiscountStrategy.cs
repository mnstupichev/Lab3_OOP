namespace Lab3.PriceCalculators.Discount;

public class NoDiscountStrategy : IDiscountStrategy
{
    public decimal CalculateDiscount(decimal amount)
    {
        return 0;
    }
}

