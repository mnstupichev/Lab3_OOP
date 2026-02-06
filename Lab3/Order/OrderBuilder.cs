using FoodDelivery.Models;

namespace FoodDelivery.Patterns.Builder
{
    public class OrderBuilder
    {
        private Order _order;

        public OrderBuilder()
        {
            _order = new Order();
        }

        public OrderBuilder AddItem(MenuItem item)
        {
            _order.AddItem(item);
            return this;
        }

        public OrderBuilder SetAddress(string address)
        {
            _order.SetAddress(address);
            return this;
        }

        public OrderBuilder SetPaid(bool paid)
        {
            _order.SetPaid(paid);
            return this;
        }

        public Order Build()
        {
            return _order;
        }

        public OrderBuilder Reset()
        {
            _order = new Order();
            return this;
        }
    }
}
