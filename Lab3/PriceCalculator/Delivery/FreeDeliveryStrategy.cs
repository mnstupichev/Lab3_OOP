namespace FoodDelivery.Patterns.Strategy
{
    public class FreeDeliveryStrategy : IDeliveryStrategy
    {
        private decimal _threshold;

        public FreeDeliveryStrategy(decimal threshold = 1000)
        {
            _threshold = threshold;
        }

        public decimal CalculateDeliveryCost(decimal orderAmount)
        {
            if (orderAmount >= _threshold)
            {
                return 0;
            }
            return 0;
        }
    }
}
