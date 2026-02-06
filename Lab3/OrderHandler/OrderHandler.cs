using FoodDelivery.Models;

namespace FoodDelivery.Patterns.Chain
{
    public abstract class OrderHandler
    {
        protected OrderHandler? _nextHandler;

        public OrderHandler SetNext(OrderHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public abstract bool Handle(Order order);

        protected bool HandleNext(Order order)
        {
            if (_nextHandler != null)
            {
                return _nextHandler.Handle(order);
            }
            return true;
        }
    }
}
