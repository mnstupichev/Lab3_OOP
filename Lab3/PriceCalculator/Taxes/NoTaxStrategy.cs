namespace FoodDelivery.Patterns.Strategy
{
    public class NoTaxStrategy : ITaxStrategy
    {
        public decimal CalculateTax(decimal amount)
        {
            return 0;
        }
    }
}
