using FoodDelivery.Models;

namespace FoodDelivery.Patterns.Chain
{
    public class AddressCheckHandler : OrderHandler
    {
        public override bool Handle(Order order)
        {
            if (string.IsNullOrEmpty(order.GetAddress()))
            {
                return false;
            }
            
            return HandleNext(order);
        }
    }
}
