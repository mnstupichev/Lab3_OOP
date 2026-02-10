namespace Lab3.OrderHandler;

public class PaymentCheckHandler : OrderHandler
{
    public override bool Handle(Order.Order order)
    {
        if (!order.Paid)
        {
            return false;
        }

        return HandleNext(order);
    }
}

