namespace Lab3.PriceCalculators.Delivery;

public class StandartDeliveryStrategy : IDeliveryStrategy
{
    private decimal _cost;

    public StandartDeliveryStrategy(decimal cost)
    {
        _cost = cost;
    }

    public decimal CalculateDeliveryCost(decimal orderAmount)
    {
        return _cost;
    }
}

