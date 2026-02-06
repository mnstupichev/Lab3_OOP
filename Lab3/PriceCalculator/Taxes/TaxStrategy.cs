namespace FoodDelivery.Patterns.Strategy
{
    public class TaxStrategy : ITaxStrategy
    {
        private decimal _rate;

        public TaxStrategy(decimal rate = 20)
        {
            _rate = rate;
        }

        public decimal CalculateTax(decimal amount)
        {
            return amount * (_rate / 100);
        }
    }
}
