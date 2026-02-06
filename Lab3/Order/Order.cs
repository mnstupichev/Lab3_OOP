using FoodDelivery.Patterns.State;

namespace FoodDelivery.Models
{
    public class Order
    {
        private List<MenuItem> _items;
        private string? _address;
        private IOrderState _state;
        private bool _isPaid;
        private decimal _totalPrice;

        public Order()
        {
            _items = new List<MenuItem>();
            _state = new CreatedState();
            _isPaid = false;
            _totalPrice = 0;
        }

        public void AddItem(MenuItem item)
        {
            _items.Add(item);
        }

        public List<MenuItem> GetItems()
        {
            return _items;
        }

        public void SetAddress(string address)
        {
            _address = address;
        }

        public string? GetAddress()
        {
            return _address;
        }

        public void SetState(IOrderState state)
        {
            _state = state;
        }

        public IOrderState GetState()
        {
            return _state;
        }

        public void NextState()
        {
            _state.Next(this);
        }

        public string GetStateName()
        {
            return _state.GetName();
        }

        public void SetPaid(bool paid)
        {
            _isPaid = paid;
        }

        public bool IsPaid()
        {
            return _isPaid;
        }

        public void SetTotalPrice(decimal price)
        {
            _totalPrice = price;
        }

        public decimal GetTotalPrice()
        {
            return _totalPrice;
        }

        public decimal GetItemsPrice()
        {
            return _items.Sum(item => item.GetPrice());
        }
    }
}
