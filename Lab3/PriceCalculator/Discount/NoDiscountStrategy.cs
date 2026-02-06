namespace FoodDelivery.Patterns.Strategy
{
    public class NoDiscountStrategy : IDiscountStrategy
    {
        public decimal CalculateDiscount(decimal amount)
        {
            return 0;
        }
    }
}
