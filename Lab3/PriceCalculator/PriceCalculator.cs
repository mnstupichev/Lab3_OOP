using FoodDelivery.Models;

namespace FoodDelivery.Patterns.Strategy
{
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
            decimal itemsTotal = order.GetItemsPrice();

            decimal discount = _discountStrategy.CalculateDiscount(itemsTotal);
            decimal amountAfterDiscount = itemsTotal - discount;

            decimal deliveryCost = _deliveryStrategy.CalculateDeliveryCost(itemsTotal);

            decimal tax = _taxStrategy.CalculateTax(amountAfterDiscount);

            decimal total = amountAfterDiscount + deliveryCost + tax;

            return total;
        }
    }
}
