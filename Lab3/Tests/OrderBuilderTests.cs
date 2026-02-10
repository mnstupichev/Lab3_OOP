using Lab3.Menu.MenuItems;
using Lab3.Order;

namespace Lab3.Tests;

public class OrderBuilderTests
{
    [Fact]
    public void OrderBuilder_WithAddress_SetsAddress()
    {
        var builder = new OrderBuilder();
        
        builder.WithAddress("Street");
        var order = builder.Build();
        
        Assert.Equal("Street", order.Address);
    }

    [Fact]
    public void OrderBuilder_WithPaid_SetsPaidStatus()
    {
        var builder = new OrderBuilder();
        
        builder.WithPaid(true);
        var order = builder.Build();
        
        Assert.True(order.Paid);
    }

    [Fact]
    public void OrderBuilder_AddItem_AddsItemToOrder()
    {
        var builder = new OrderBuilder();
        var item = new Potato();
        
        builder.AddItem(item);
        var order = builder.Build();
        
        Assert.Single(order.Items);
        Assert.Contains(item, order.Items);
    }

    [Fact]
    public void OrderBuilder_AddMultipleItems_AddsAllItems()
    {
        var builder = new OrderBuilder();
        var item1 = new Potato();
        var item2 = new Burger();
        
        builder.AddItem(item1).AddItem(item2);
        var order = builder.Build();
        
        Assert.Equal(2, order.Items.Count);
        Assert.Contains(item1, order.Items);
        Assert.Contains(item2, order.Items);
    }

    [Fact]
    public void OrderBuilder_Build_CreatesNewOrder()
    {
        var builder = new OrderBuilder();
        
        var order = builder
            .WithAddress("Street")
            .WithPaid(false)
            .Build();
        
        Assert.NotNull(order);
        Assert.Equal("Street", order.Address);
    }

    [Fact]
    public void OrderBuilder_EmptyBuilder_CreatesOrderWithEmptyItems()
    {
        var builder = new OrderBuilder();
        
        var order = builder.Build();
        
        Assert.NotNull(order.Items);
        Assert.Empty(order.Items);
    }
}
