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
    public void CreateStandardChain_ChecksItemsFirst()
    {
        var chain = new StandartHandlerFactory();
        var items = new List<IMenuItem>
        {
            new Burger()
        };
        var order = new Order("Address", false, items);
        
        var result = chain.CreatHandler();
        
        result.Handle(order);
    
        Assert.False(result);
    }

    [Fact]
    public void CreateStandardChain_WithValidItemsButNoAddress_FailsOnAddress()
    {
        var chain = OrderChainFactory.CreateStandardChain();
        var items = new List<IMenuItem>
        {
            new Potato()
        };
        var order = new Order("", false, items);
        
        var result = chain.Handle(order);
 
        Assert.False(result);
    }

    [Fact]
    public void CreateStandardChain_WithValidItemsAndAddress_FailsOnPayment()
    {
        var chain = OrderChainFactory.CreateStandardChain();
        var items = new List<IMenuItem>
        {
            new Potato()
        };
        var order = new Order("Address", false, items);
        
        var result = chain.Handle(order);
        
        Assert.False(result);
    }

    [Fact]
    public void CreateStandardChain_CustomWorkingHours()
    {
        var chain = OrderChainFactory.CreateStandardChain(10, 20);
        
        Assert.NotNull(chain);
    }

    [Fact]
    public void CreatePickupChain_ReturnsValidChain()
    {
        var chain = OrderChainFactory.CreatePickupChain();
        
        Assert.NotNull(chain);
        Assert.IsType<ItemsAvailabilityHandler>(chain);
    }

    [Fact]
    public void CreatePickupChain_SkipsAddressCheck()
    {
        var chain = OrderChainFactory.CreatePickupChain();
        var items = new List<IMenuItem>
        {
            new Potato()
        };
        var order = new Order("", false, items);
        
        var result = chain.Handle(order);
        Assert.False(result);
    }

    [Fact]
    public void CreatePickupChain_ChecksItemsFirst()
    {
        var chain = OrderChainFactory.CreatePickupChain();
        var items = new List<IMenuItem>
        {
            new Burger()
        };
        var order = new Order("", false, items);
        
        var result = chain.Handle(order);
        Assert.False(result);
    }

    [Fact]
    public void CreatePickupChain_CustomWorkingHours()
    {
        var chain = OrderChainFactory.CreatePickupChain(8, 23);
        
        Assert.NotNull(chain);
    }
}
