using FoodDelivery.Models;

namespace FoodDelivery.Patterns.Chain
{
    public class RestaurantWorkingHandler : OrderHandler
    {
        private int _openingHour;
        private int _closingHour;

        public RestaurantWorkingHandler(int openingHour = 9, int closingHour = 22)
        {
            _openingHour = openingHour;
            _closingHour = closingHour;
        }

        public override bool Handle(Order order)
        {
            int currentHour = DateTime.Now.Hour;

            if (currentHour < _openingHour || currentHour >= _closingHour)
            {
                return false;
            }

            return HandleNext(order);
        }
    }
}
