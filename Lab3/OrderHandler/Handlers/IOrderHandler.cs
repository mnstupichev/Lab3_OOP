using Lab3.Orders;

namespace Lab3.OrderHandler.Handlers;

public interface IOrderHandler
{
    OrderHandler SetNext(OrderHandler handler);
    bool Handle(Order order);
}