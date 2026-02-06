namespace FoodDelivery.Patterns.Strategy
{
    public class StandardDeliveryStrategy : IDeliveryStrategy
    {
        private decimal _cost;

        public StandardDeliveryStrategy(decimal cost)
        {
            _cost = cost;
        }

        public decimal CalculateDeliveryCost(decimal orderAmount)
        {
            return _cost;
        }
    }
}
