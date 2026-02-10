namespace Lab3.OrderHandler.Handlers;

public class ItemsAvailabilityHandler : OrderHandler
{
    public override bool Handle(Order.Order order)
    {
        var items = order.Items;

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

