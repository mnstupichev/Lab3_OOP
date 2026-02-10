namespace Lab3.OrderHandler;

public class OrderChainFactory
{
    public static OrderHandler CreateStandardChain(int openingHour = 9, int closingHour = 22)
    {
        var itemsHandler = new ItemsAvailabilityHandler();
        var addressHandler = new AddressCheckHandler();
        var paymentHandler = new PaymentCheckHandler();
        var workingHoursHandler = new RestaurantWorkingHandler(openingHour, closingHour);

        itemsHandler
            .SetNext(addressHandler)
            .SetNext(paymentHandler)
            .SetNext(workingHoursHandler);

        return itemsHandler;
    }

    public static OrderHandler CreatePickupChain(int openingHour = 9, int closingHour = 22)
    {
        var itemsHandler = new ItemsAvailabilityHandler();
        var paymentHandler = new PaymentCheckHandler();
        var workingHoursHandler = new RestaurantWorkingHandler(openingHour, closingHour);

        itemsHandler
            .SetNext(paymentHandler)
            .SetNext(workingHoursHandler);

        return itemsHandler;
    }
}