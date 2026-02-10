namespace Lab3.OrderHandler;

public class AddressCheckHandler : OrderHandler
{
    public override bool Handle(Order.Order order)
    {
        if (string.IsNullOrEmpty(order.Address))
        {
            return false;
        }
            
        return HandleNext(order);
    }
}