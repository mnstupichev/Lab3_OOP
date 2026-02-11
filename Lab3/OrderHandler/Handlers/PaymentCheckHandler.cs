using Lab3.Orders;

namespace Lab3.OrderHandler.Handlers;

public class PaymentCheckHandler : OrderHandler
{
    public override bool Handle(Order order)
    {
        if (!order.IsPaid)
        {
            return false;
        }

        return HandleNext(order);
    }
}

