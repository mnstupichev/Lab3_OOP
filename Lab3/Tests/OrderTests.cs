using Lab3.Menu;
using Lab3.Menu.MenuItems;
using Lab3.Order;

namespace Lab3.Tests;

public class OrderTests
{
    [Fact]
    public void Order_Constructor_InitializesWithParameters()
    {
        var items = new List<IMenuItem> 
        { 
            new Potato()
        };
        var order = new Order.Order("Street", true, items);
        
        Assert.NotNull(order.Items);
        Assert.Single(order.Items);
    }

    [Fact]
    public void Order_Paid_ReturnsFalse()
    {
        var order = new Order.Order("Street", false, new List<IMenuItem>());
      
        Assert.False(order.Paid);
    }

    [Fact]
    public void Order_ChangeStage_ChangesStage()
    {
        var order = new Order.Order("Street", false, new List<IMenuItem>());
        
        order.ChangeStage(OrderStage.Preparing);
        
        Assert.Equal(OrderStage.Preparing, order._stage);
    }

    [Fact]
    public void Order_InitialStage_IsCreated()
    {
        var order = new Order.Order("Street", false, new List<IMenuItem>());
        
        Assert.Equal(OrderStage.Created, order._stage);
    }

    [Fact]
    public void Order_Address_CanBeSet()
    {
        var order = new Order.Order("Street", false, new List<IMenuItem>());
        
        Assert.Equal("Street", order.Address);
    }

    [Fact]
    public void Order_Items_CanBeAccessed()
    {
        var items = new List<IMenuItem> 
        { 
            new Potato(),
            new Burger()
        };
        var order = new Order.Order("Street", false, items);
        
        Assert.Equal(2, order.Items.Count);
    }
}
