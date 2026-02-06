using FoodDelivery.Models;

namespace FoodDelivery.Patterns.Chain
{
    public class PaymentCheckHandler : OrderHandler
    {
        public override bool Handle(Order order)
        {
            if (!order.IsPaid())
            {
                return false;
            }

            return HandleNext(order);
        }
    }
}
