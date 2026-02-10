using Lab3.Menu;
using Lab3.OrderHandler;

namespace Lab3.Tests;

public class OrderHandlerTests
{
    [Fact]
    public void PaymentCheckHandler_OrderNotPaid_ReturnsFalse()
    {
        var handler = new PaymentCheckHandler();
        var order = new Order.Order();
        order.SetPaid(false);
            
        var result = handler.Handle(order);
            
        Assert.False(result);
    }

    [Fact]
    public void PaymentCheckHandler_OrderPaid_ReturnsTrue()
    {
        var handler = new PaymentCheckHandler();
        var order = new Order.Order();
        order.SetPaid(true);
            
        var result = handler.Handle(order);
            
        Assert.True(result);
    }

    [Fact]
    public void AddressCheckHandler_NoAddress_ReturnsFalse()
    {
        var handler = new AddressCheckHandler();
        var order = new Order.Order();
            
        var result = handler.Handle(order);
            
        Assert.False(result);
    }

    [Fact]
    public void AddressCheckHandler_EmptyAddress_ReturnsFalse()
    {
        var handler = new AddressCheckHandler();
        var order = new Order.Order();
        order.SetAddress("");
            
        var result = handler.Handle(order);
            
        Assert.False(result);
    }

    [Fact]
    public void AddressCheckHandler_ValidAddress_ReturnsTrue()
    {
        var handler = new AddressCheckHandler();
        var order = new Order.Order();
        order.SetAddress("Test Street 123");
            
        var result = handler.Handle(order);
            
        Assert.True(result);
    }

    [Fact]
    public void ItemsAvailabilityHandler_NoItems_ReturnsFalse()
    {
        var handler = new ItemsAvailabilityHandler();
        var order = new Order.Order();
            
        var result = handler.Handle(order);
            
        Assert.False(result);
    }

    [Fact]
    public void ItemsAvailabilityHandler_AllItemsAvailable_ReturnsTrue()
    {
        var handler = new ItemsAvailabilityHandler();
        var order = new Order.Order();
        order.Add(new MenuItemBase("Pizza", 500m, true));
        order.Add(new MenuItemBase("Burger", 300m, true));
            
        var result = handler.Handle(order);
            
        Assert.True(result);
    }

    [Fact]
    public void ItemsAvailabilityHandler_OneItemUnavailable_ReturnsFalse()
    {
        var handler = new ItemsAvailabilityHandler();
        var order = new Order.Order();
        order.Add(new MenuItemBase("Pizza", 500m, true));
        order.Add(new MenuItemBase("Burger", 300m, false));
            
        var result = handler.Handle(order);
            
        Assert.False(result);
    }

    [Fact]
    public void RestaurantWorkingHandler_OutsideWorkingHours_ReturnsFalse()
    {
        var handler = new RestaurantWorkingHandler(9, 22);
        var order = new Order.Order();
        var currentHour = DateTime.Now.Hour;
            
        if (currentHour < 9 || currentHour >= 22)
        {
            var result = handler.Handle(order);
            Assert.False(result);
        }
    }

    [Fact]
    public void OrderHandlerChain_AllChecksPass_ReturnsTrue()
    {
        var paymentHandler = new PaymentCheckHandler();
        var addressHandler = new AddressCheckHandler();
        var itemsHandler = new ItemsAvailabilityHandler();
            
        paymentHandler.SetNext(addressHandler).SetNext(itemsHandler);
            
        var order = new Order.Order();
        order.SetPaid(true);
        order.SetAddress("Test Street 123");
        order.Add(new MenuItemBase("Pizza", 500m, true));
            
        var result = paymentHandler.Handle(order);
            
        Assert.True(result);
    }

    [Fact]
    public void OrderHandlerChain_PaymentFails_ReturnsFalse()
    {
        var paymentHandler = new PaymentCheckHandler();
        var addressHandler = new AddressCheckHandler();
            
        paymentHandler.SetNext(addressHandler);
            
        var order = new Order.Order();
        order.SetPaid(false);
        order.SetAddress("Test Street 123");
            
        var result = paymentHandler.Handle(order);
            
        Assert.False(result);
    }

    [Fact]
    public void OrderHandlerChain_AddressFails_ReturnsFalse()
    {
        var paymentHandler = new PaymentCheckHandler();
        var addressHandler = new AddressCheckHandler();
        var itemsHandler = new ItemsAvailabilityHandler();
            
        paymentHandler.SetNext(addressHandler).SetNext(itemsHandler);
            
        var order = new Order.Order();
        order.SetPaid(true);
        order.SetAddress("");
        order.Add(new MenuItemBase("Pizza", 500m, true));
            
        var result = paymentHandler.Handle(order);
            
        Assert.False(result);
    }

    [Fact]
    public void OrderHandlerChain_ItemsFails_ReturnsFalse()
    {
        var paymentHandler = new PaymentCheckHandler();
        var addressHandler = new AddressCheckHandler();
        var itemsHandler = new ItemsAvailabilityHandler();
            
        paymentHandler.SetNext(addressHandler).SetNext(itemsHandler);
            
        var order = new Order.Order();
        order.SetPaid(true);
        order.SetAddress("Test Street 123");
        order.Add(new MenuItemBase("Pizza", 500m, false));
            
        var result = paymentHandler.Handle(order);
            
        Assert.False(result);
    }
}