namespace Lab3.PriceCalculators.Taxes;

public class NoTaxStrategy : ITaxStrategy
{
    public decimal CalculateTax(decimal amount)
    {
        return 0;
    }
}