using Lab3.OrderHandler.Handlers;

namespace Lab3.OrderHandler.OrderHandlersFactories;

public class PickUpHandlerFactory :  IOrderHandlerFactory
{
    private int _openingHour;
    private int _closingHour;
    
    public PickUpHandlerFactory(int openingHour = 9, int closingHour = 22)
    {
        _openingHour = openingHour;
        _closingHour = closingHour;
    }
    
    public IOrderHandler CreatHandler()
    {
        var itemsAvailabilityHandler = new ItemsAvailabilityHandler();
        var paymentCheckHandler = new PaymentCheckHandler();
        var restaurantWorkingHandler = new RestaurantWorkingHandler(_openingHour, _closingHour);
    
        itemsAvailabilityHandler.SetNext(paymentCheckHandler);
        paymentCheckHandler.SetNext(restaurantWorkingHandler);

        return itemsAvailabilityHandler;
    }
}