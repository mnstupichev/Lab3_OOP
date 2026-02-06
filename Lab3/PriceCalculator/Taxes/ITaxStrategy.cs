namespace FoodDelivery.Patterns.Strategy
{
    public interface ITaxStrategy
    {
        decimal CalculateTax(decimal amount);
    }
}
