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
        return new ItemsAvailabilityHandler()
            .SetNext(new AddressCheckHandler())
            .SetNext(new PaymentCheckHandler())
            .SetNext(new RestaurantWorkingHandler(_openingHour, _closingHour));
    }
}