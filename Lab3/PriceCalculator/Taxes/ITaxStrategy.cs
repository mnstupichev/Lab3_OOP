namespace Lab3.PriceCalculator.Taxes;

public interface ITaxStrategy
{
    decimal CalculateTax(decimal amount);
}