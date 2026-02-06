using FoodDelivery.Models;

namespace FoodDelivery.Patterns.State
{
    public class DeliveringState : IOrderState
    {
        public void Next(Order order)
        {
            order.SetState(new CompletedState());
        }

        public string GetName()
        {
            return "Delivering";
        }
    }
}
