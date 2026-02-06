using FoodDelivery.Models;

namespace FoodDelivery.Patterns.State
{
    public class PreparingState : IOrderState
    {
        public void Next(Order order)
        {
            order.SetState(new DeliveringState());
        }

        public string GetName()
        {
            return "Preparing";
        }
    }
}
