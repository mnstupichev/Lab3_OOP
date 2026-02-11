using Lab3.Orders;
using Lab3.PriceCalculators.Delivery;
using Lab3.PriceCalculators.Discount;
using Lab3.PriceCalculators.Taxes;

namespace Lab3.PriceCalculators;

public class PriceCalculator
{
    private IDiscountStrategy _discountStrategy;
    private IDeliveryStrategy _deliveryStrategy;
    private ITaxStrategy _taxStrategy;

    public PriceCalculator(
        IDiscountStrategy discountStrategy,
        IDeliveryStrategy deliveryStrategy,
        ITaxStrategy taxStrategy)
    {
        _discountStrategy = discountStrategy;
        _deliveryStrategy = deliveryStrategy;
        _taxStrategy = taxStrategy;
    }

    public decimal CalculateTotal(Order order)
    {
        decimal itemsTotal = order.Items.Sum(item => item.Price);

        decimal discount = _discountStrategy.CalculateDiscount(itemsTotal);
        decimal amountAfterDiscount = itemsTotal - discount;

        decimal deliveryCost = _deliveryStrategy.CalculateDeliveryCost(itemsTotal);

        decimal tax = _taxStrategy.CalculateTax(amountAfterDiscount);

        decimal total = amountAfterDiscount + deliveryCost + tax;

        return total;
    }
}

