using Xunit;
using FoodDelivery.Models;
using FoodDelivery.Patterns.Builder;
using FoodDelivery.Patterns.Composite;
using FoodDelivery.Patterns.State;

namespace FoodDelivery.Tests
{
    public class OrderTests
    {
        [Fact]
        public void Order_InitialState_IsCreated()
        {
            var order = new Order();
            
            Assert.Equal("Created", order.GetStateName());
        }

        [Fact]
        public void Order_AddItem_ItemIsAdded()
        {
            var order = new Order();
            var item = new MenuItemBuilder("Pizza", 500m);
            
            order.AddItem(item);
            
            Assert.Single(order.GetItems());
            Assert.Contains(item, order.GetItems());
        }

        [Fact]
        public void Order_SetAddress_AddressIsSet()
        {
            var order = new Order();
            
            order.SetAddress("Test Street 123");
            
            Assert.Equal("Test Street 123", order.GetAddress());
        }

        [Fact]
        public void Order_SetPaid_PaidStatusIsSet()
        {
            var order = new Order();
            
            order.SetPaid(true);
            
            Assert.True(order.IsPaid());
        }

        [Fact]
        public void Order_GetItemsPrice_CalculatesCorrectTotal()
        {
            var order = new Order();
            order.AddItem(new MenuItemBuilder("Pizza", 500m));
            order.AddItem(new MenuItemBuilder("Burger", 300m));
            
            var total = order.GetItemsPrice();
            
            Assert.Equal(800m, total);
        }

        [Fact]
        public void Order_SetTotalPrice_TotalPriceIsSet()
        {
            var order = new Order();
            
            order.SetTotalPrice(1000m);
            
            Assert.Equal(1000m, order.GetTotalPrice());
        }

        [Fact]
        public void OrderBuilder_Build_CreatesOrderWithItems()
        {
            var builder = new OrderBuilder();
            var item = new MenuItemBuilder("Pizza", 500m);
            
            var order = builder
                .AddItem(item)
                .SetAddress("Test Street")
                .SetPaid(true)
                .Build();
            
            Assert.Single(order.GetItems());
            Assert.Equal("Test Street", order.GetAddress());
            Assert.True(order.IsPaid());
        }

        [Fact]
        public void OrderBuilder_Reset_CreatesNewOrder()
        {
            var builder = new OrderBuilder();
            builder.AddItem(new MenuItemBuilder("Pizza", 500m));
            
            builder.Reset();
            var newOrder = builder.Build();
            
            Assert.Empty(newOrder.GetItems());
        }
    }
}
