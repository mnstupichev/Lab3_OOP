using FoodDelivery.Models;

namespace FoodDelivery.Patterns.Composite
{
    public class MenuItemBuilder : MenuItem
    {
        private string _name;
        private decimal _price;
        private bool _available;

        public MenuItemBuilder(string name, decimal price, bool available = true)
        {
            _name = name;
            _price = price;
            _available = available;
        }

        public override string GetName()
        {
            return _name;
        }

        public override decimal GetPrice()
        {
            return _price;
        }

        public override bool IsAvailable()
        {
            return _available;
        }

        public void SetAvailable(bool available)
        {
            _available = available;
        }
    }
}
