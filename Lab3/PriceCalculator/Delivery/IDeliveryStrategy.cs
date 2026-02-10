namespace Lab3.PriceCalculator.Delivery;

public interface IDeliveryStrategy
{
    decimal CalculateDeliveryCost(decimal orderAmount);
}