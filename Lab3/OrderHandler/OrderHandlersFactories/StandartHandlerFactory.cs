using Lab3.OrderHandler.Handlers;

namespace Lab3.OrderHandler.OrderHandlersFactories;

public class StandartHandlerFactory : IOrderHandlerFactory
{
    private int _openingHour;
    private int _closingHour;
    
    public StandartHandlerFactory(int openingHour = 9, int closingHour = 22)
    {
        _openingHour = openingHour;
        _closingHour = closingHour;
    }
    
    public IOrderHandler CreatHandler()
    {
        var itemsAvailabilityHandler = new ItemsAvailabilityHandler();
        var addressCheckHandler = new AddressCheckHandler();
        var paymentCheckHandler = new PaymentCheckHandler();
        var restaurantWorkingHandler = new RestaurantWorkingHandler(_openingHour, _closingHour);
    
        itemsAvailabilityHandler.SetNext(addressCheckHandler);
        addressCheckHandler.SetNext(paymentCheckHandler);
        paymentCheckHandler.SetNext(restaurantWorkingHandler);

        return itemsAvailabilityHandler;
    }
}