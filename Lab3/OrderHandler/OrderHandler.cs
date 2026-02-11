using Lab3.OrderHandler.Handlers;
using Lab3.Orders;

namespace Lab3.OrderHandler;

public abstract class OrderHandler :  IOrderHandler
{
    protected OrderHandler? NextHandler;

    public OrderHandler SetNext(OrderHandler handler)
    {
        NextHandler = handler;
        return handler;
    }

    public abstract bool Handle(Order order);

    protected bool HandleNext(Order order)
    {
        if (NextHandler != null)
        {
            return NextHandler.Handle(order);
        }
        return true;
    }
}

