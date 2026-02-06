namespace FoodDelivery.Patterns.Strategy
{
    public class ExpressDeliveryStrategy : IDeliveryStrategy
    {
        private decimal _cost;

        public ExpressDeliveryStrategy(decimal cost)
        {
            _cost = cost;
        }

        public decimal CalculateDeliveryCost(decimal orderAmount)
        {
            return _cost;
        }
    }
}
