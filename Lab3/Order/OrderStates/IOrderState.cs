using FoodDelivery.Models;

namespace FoodDelivery.Patterns.State
{
    public interface IOrderState
    {
        void Next(Order order);
        string GetName();
    }
}
