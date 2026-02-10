using Lab3.Menu;
using Lab3.Order;

namespace Lab3.Tests;

public class OrderTests
{
    [Fact]
    public void Order_InitialState_IsCreated()
    {
        var order = new Order.Order();
            
        Assert.Equal("Created", order.GetStateName());
    }

    [Fact]
    public void Order_AddItem_ItemIsAdded()
    {
        var order = new Order.Order();
        var item = new MenuItemBase("Pizza", 500m);
            
        order.Add(item);
            
        Assert.Single(order.GetItems());
        Assert.Contains(item, order.GetItems());
    }

    [Fact]
    public void Order_SetAddress_AddressIsSet()
    {
        var order = new Order.Order();
            
        order.SetAddress("Test Street 123");
            
        Assert.Equal("Test Street 123", order.GetAddress());
    }

    [Fact]
    public void Order_SetPaid_PaidStatusIsSet()
    {
        var order = new Order.Order();
            
        order.SetPaid(true);
            
        Assert.True(order.IsPaid());
    }

    [Fact]
    public void Order_GetItemsPrice_CalculatesCorrectTotal()
    {
        var order = new Order.Order();
        order.Add(new MenuItemBase("Pizza", 500m));
        order.Add(new MenuItemBase("Burger", 300m));
            
        var total = order.GetItemsPrice();
            
        Assert.Equal(800m, total);
    }

    [Fact]
    public void Order_SetTotalPrice_TotalPriceIsSet()
    {
        var order = new Order.Order();
            
        order.SetTotalPrice(1000m);
            
        Assert.Equal(1000m, order.GetTotalPrice());
    }

    [Fact]
    public void OrderBuilder_Build_CreatesOrderWithItems()
    {
        var builder = new OrderBuilder();
        var item = new MenuItemBase("Pizza", 500m);
            
        var order = builder
            .WithItem(item)
            .WithAddress("Test Street")
            .WithPaid(true)
            .Build();
            
        Assert.Single(order.GetItems());
        Assert.Equal("Test Street", order.GetAddress());
        Assert.True(order.IsPaid());
    }

    [Fact]
    public void OrderBuilder_Reset_CreatesNewOrder()
    {
        var builder = new OrderBuilder();
        builder.WithItem(new MenuItemBase("Pizza", 500m));
            
        builder.Reset();
        var newOrder = builder.Build();
            
        Assert.Empty(newOrder.GetItems());
    }
}