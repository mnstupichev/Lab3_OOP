namespace Lab3.PriceCalculator.Discount;

public interface IDiscountStrategy
{
    decimal CalculateDiscount(decimal amount);
}

