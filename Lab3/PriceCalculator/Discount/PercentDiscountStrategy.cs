namespace FoodDelivery.Patterns.Strategy
{
    public class PercentDiscountStrategy : IDiscountStrategy
    {
        private decimal _percent;

        public PercentDiscountStrategy(decimal percent)
        {
            _percent = percent;
        }

        public decimal CalculateDiscount(decimal amount)
        {
            return amount * (_percent / 100);
        }
    }
}
