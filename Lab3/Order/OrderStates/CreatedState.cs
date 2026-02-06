using FoodDelivery.Models;

namespace FoodDelivery.Patterns.State
{
    public class CreatedState : IOrderState
    {
        public void Next(Order order)
        {
            order.SetState(new PreparingState());
        }

        public string GetName()
        {
            return "Created";
        }
    }
}
