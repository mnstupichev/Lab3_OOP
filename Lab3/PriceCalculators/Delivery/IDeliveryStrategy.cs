namespace Lab3.PriceCalculators.Delivery;

public interface IDeliveryStrategy
{
    decimal CalculateDeliveryCost(decimal orderAmount);
}