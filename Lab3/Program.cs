using FoodDelivery.Models;
using FoodDelivery.Patterns.Composite;
using FoodDelivery.Patterns.Builder;
using FoodDelivery.Patterns.Strategy;
using FoodDelivery.Patterns.Chain;

namespace FoodDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Food Delivery System Demo ===\n");

            Console.WriteLine("--- Creating Menu Items (Composite Pattern) ---");
            var potato = new MenuItemBuilder("Картошка", 150);
            var burger = new MenuItemBuilder("Бургер", 350);

            var combo = new ComboMenuItem("Комбо №1");
            combo.AddItem(burger);
            combo.AddItem(potato);

            Console.WriteLine($"Simple items: {potato.GetName()} - {potato.GetPrice()} руб.");
            Console.WriteLine($"Simple items: {burger.GetName()} - {burger.GetPrice()} руб.");
            Console.WriteLine($"Combo: {combo.GetName()} - {combo.GetPrice()} руб.\n");

            Console.WriteLine("--- Building Order (Builder Pattern) ---");
            var builder = new OrderBuilder();
            var order = builder
                .AddItem(combo)
                .AddItem(potato)
                .SetAddress("ул. Ленина, д. 10")
                .SetPaid(true)
                .Build();

            Console.WriteLine($"Order created with {order.GetItems().Count} items");
            Console.WriteLine($"Address: {order.GetAddress()}");
            Console.WriteLine($"Items total: {order.GetItemsPrice()} руб.\n");

            Console.WriteLine("--- Calculating Price (Strategy Pattern) ---");

            var calculator1 = new PriceCalculator(
                new NoDiscountStrategy(),
                new StandardDeliveryStrategy(200),
                new TaxStrategy(20)
            );
            decimal total1 = calculator1.CalculateTotal(order);
            Console.WriteLine($"With standard delivery, no discount, VAT 20%: {total1} руб.");

            var calculator2 = new PriceCalculator(
                new PercentDiscountStrategy(10),
                new FreeDeliveryStrategy(1000),
                new NoTaxStrategy()
            );
            decimal total2 = calculator2.CalculateTotal(order);
            Console.WriteLine($"With free delivery (order < 1000), 10% discount, no tax: {total2} руб.");

            order.SetTotalPrice(total1);
            Console.WriteLine();

            Console.WriteLine("--- Validating Order (Chain of Responsibility Pattern) ---");
            var addressHandler = new AddressCheckHandler();
            var restaurantHandler = new RestaurantWorkingHandler();
            var availabilityHandler = new ItemsAvailabilityHandler();
            var paymentHandler = new PaymentCheckHandler();
            var submitHandler = new RestaurantSubmitHandler();

            addressHandler
                .SetNext(restaurantHandler)
                .SetNext(availabilityHandler)
                .SetNext(paymentHandler)
                .SetNext(submitHandler);

            bool validationResult = addressHandler.Handle(order);

            if (validationResult)
            {
                Console.WriteLine("\n✓ All validations passed! Order is ready for processing.\n");
            }
            else
            {
                Console.WriteLine("\n✗ Order validation failed!\n");
            }

            Console.WriteLine("--- Order State Transitions (State Pattern) ---");
            Console.WriteLine($"Initial state: {order.GetStateName()}");

            order.NextState();
            Console.WriteLine($"After NextState(): {order.GetStateName()}");

            order.NextState();
            Console.WriteLine($"After NextState(): {order.GetStateName()}");

            order.NextState();
            Console.WriteLine($"After NextState(): {order.GetStateName()}");

            Console.WriteLine("\n--- Testing unavailable item ---");
            var builder2 = new OrderBuilder();
            var unavailablePotato = new MenuItemBuilder("Картошка", 150, false);
            var order2 = builder2
                .AddItem(unavailablePotato)
                .SetAddress("ул. Пушкина, д. 5")
                .SetPaid(true)
                .Build();

            Console.WriteLine("Validating order with unavailable item:");
            addressHandler.Handle(order2);

            Console.WriteLine("\n--- Testing order without address ---");
            var builder3 = new OrderBuilder();
            var order3 = builder3
                .AddItem(burger)
                .SetPaid(true)
                .Build();

            Console.WriteLine("Validating order without address:");
            addressHandler.Handle(order3);

            Console.WriteLine("\n=== Demo Completed ===");
        }
    }
}
