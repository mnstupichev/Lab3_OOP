namespace FoodDelivery.Models
{
    public abstract class MenuItem
    {
        public abstract string GetName();
        public abstract decimal GetPrice();
        public abstract bool IsAvailable();
    }
}
