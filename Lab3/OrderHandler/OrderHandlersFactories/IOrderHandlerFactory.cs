using Lab3.OrderHandler.Handlers;

namespace Lab3.OrderHandler.OrderHandlersFactories;

public interface IOrderHandlerFactory
{
    IOrderHandler CreatHandler();
}