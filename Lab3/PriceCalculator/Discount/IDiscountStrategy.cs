namespace FoodDelivery.Patterns.Strategy
{
    public interface IDiscountStrategy
    {
        decimal CalculateDiscount(decimal amount);
    }
}
