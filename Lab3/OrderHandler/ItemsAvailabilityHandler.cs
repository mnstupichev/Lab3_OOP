using FoodDelivery.Models;

namespace FoodDelivery.Patterns.Chain
{
    public class ItemsAvailabilityHandler : OrderHandler
    {
        public override bool Handle(Order order)
        {
            var items = order.GetItems();

            if (items.Count == 0)
            {
                return false;
            }

            foreach (var item in items)
            {
                if (!item.IsAvailable())
                {
                    return false;
                }
            }

            return HandleNext(order);
        }
    }
}
