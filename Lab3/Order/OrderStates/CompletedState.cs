using FoodDelivery.Models;

namespace FoodDelivery.Patterns.State
{
    public class CompletedState : IOrderState
    {
        public void Next(Order order)
        {
        }

        public string GetName()
        {
            return "Completed";
        }
    }
}
