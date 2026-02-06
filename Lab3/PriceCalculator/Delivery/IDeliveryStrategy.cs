namespace FoodDelivery.Patterns.Strategy
{
    public interface IDeliveryStrategy
    {
        decimal CalculateDeliveryCost(decimal orderAmount);
    }
}
