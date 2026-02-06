using FoodDelivery.Models;

namespace FoodDelivery.Patterns.Composite
{
    public class ComboMenuItem : MenuItem
    {
        private string _name;
        private List<MenuItem> _items;

        public ComboMenuItem(string name)
        {
            _name = name;
            _items = new List<MenuItem>();
        }

        public void AddItem(MenuItem item)
        {
            _items.Add(item);
        }

        public void RemoveItem(MenuItem item)
        {
            _items.Remove(item);
        }

        public override string GetName()
        {
            var itemNames = string.Join(", ", _items.Select(item => item.GetName()));
            return $"{_name} ({itemNames})";
        }

        public override decimal GetPrice()
        {
            return _items.Sum(item => item.GetPrice());
        }

        public override bool IsAvailable()
        {
            return _items.All(item => item.IsAvailable());
        }
    }
}
