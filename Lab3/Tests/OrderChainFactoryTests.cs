using Lab3.Menu;
using Lab3.Menu.MenuItems;
using Lab3.OrderHandler;
using Lab3.OrderHandler.Handlers;
using Lab3.OrderHandler.OrderHandlersFactories;
using Lab3.Orders;

namespace Lab3.Tests;

public class OrderChainFactoryTests
{
    [Fact]
    public void StandardHandler_WorksCorrectly()
    {
        var items = new List<IMenuItem>
        {
            new Potato()
        };
        var order = new Order("Address", true, items);

        var handler = new StandartHandlerFactory().CreatHandler();
        var result = handler.Handle(order);
        
        Assert.True(result);
    }
    
    [Fact]
    public void StandardHandler_ChecksItemsAvailability()
    {
        var items = new List<IMenuItem>
        {
            new Burger()
        };
        var order = new Order("Address", true, items);

        var handler = new StandartHandlerFactory().CreatHandler();
        var result = handler.Handle(order);
        
        Assert.False(result);
    }
    
    [Fact]
    public void StandardHandler_ChecksAddressName()
    {
        var items = new List<IMenuItem>
        {
            new Potato()
        };
        var order = new Order("", true, items);

        var handler = new StandartHandlerFactory().CreatHandler();
        var result = handler.Handle(order);
        
        Assert.False(result);
    }
    
    [Fact]
    public void StandardHandler_ChecksIsPaid()
    {
        var items = new List<IMenuItem>
        {
            new Potato()
        };
        var order = new Order("Address", false, items);

        var handler = new StandartHandlerFactory().CreatHandler();
        var result = handler.Handle(order);
        
        Assert.False(result);
    }
    
    [Fact]
    public void PickUpHandler_IgnoresAddress()
    {
        var items = new List<IMenuItem>
        {
            new Potato()
        };
        var order = new Order("", true, items);

        var handler = new PickUpHandlerFactory().CreatHandler();
        var result = handler.Handle(order);
        
        Assert.True(result);
    }
}

