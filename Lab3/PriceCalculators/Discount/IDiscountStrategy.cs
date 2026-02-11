namespace Lab3.PriceCalculators.Discount;

public interface IDiscountStrategy
{
    decimal CalculateDiscount(decimal amount);
}

