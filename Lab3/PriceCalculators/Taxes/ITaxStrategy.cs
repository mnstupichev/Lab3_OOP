namespace Lab3.PriceCalculators.Taxes;

public interface ITaxStrategy
{
    decimal CalculateTax(decimal amount);
}