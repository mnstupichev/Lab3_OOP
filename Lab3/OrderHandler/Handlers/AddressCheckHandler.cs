using Lab3.Orders;

namespace Lab3.OrderHandler.Handlers;

public class AddressCheckHandler : OrderHandler
{
    public override bool Handle(Order order)
    {
        if (string.IsNullOrEmpty(order.Address))
        {
            return false;
        }
            
        return HandleNext(order);
    }
}