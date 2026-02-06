# Food Delivery System - Лабораторная работа по ООП

Система управления заказами в службе доставки еды с использованием паттернов проектирования.

## Структура проекта

```
FoodDelivery/
├── Models/
│   ├── MenuItem.cs          # Абстрактный класс для элементов меню
│   └── Order.cs             # Класс заказа
├── Patterns/
│   ├── Builder/
│   │   └── OrderBuilder.cs  # Строитель заказов
│   ├── Composite/
│   │   ├── SimpleMenuItem.cs    # Простое блюдо
│   │   └── ComboMenuItem.cs     # Комбо-набор
│   ├── State/
│   │   ├── IOrderState.cs       # Интерфейс состояния
│   │   ├── CreatedState.cs      # Создан
│   │   ├── PreparingState.cs    # Готовится
│   │   ├── DeliveringState.cs   # Доставляется
│   │   └── CompletedState.cs    # Выполнен
│   ├── Strategy/
│   │   ├── IDiscountStrategy.cs
│   │   ├── NoDiscountStrategy.cs
│   │   ├── PercentDiscountStrategy.cs
│   │   ├── IDeliveryStrategy.cs
│   │   ├── StandardDeliveryStrategy.cs
│   │   ├── FreeDeliveryStrategy.cs
│   │   ├── ExpressDeliveryStrategy.cs
│   │   ├── ITaxStrategy.cs
│   │   ├── VATTaxStrategy.cs
│   │   ├── NoTaxStrategy.cs
│   │   └── PriceCalculator.cs
│   └── Chain/
│       ├── OrderHandler.cs
│       ├── AddressCheckHandler.cs
│       ├── RestaurantWorkingHandler.cs
│       ├── ItemsAvailabilityHandler.cs
│       ├── PaymentCheckHandler.cs
│       └── RestaurantSubmitHandler.cs
└── Program.cs               # Точка входа с демонстрацией

```

## Использованные паттерны

### 1. Builder (Строитель)
**Файлы**: `Patterns/Builder/OrderBuilder.cs`

**Назначение**: Создание сложных объектов Order с множеством опциональных параметров.

**Обоснование**: Заказ содержит множество параметров (блюда, адрес, статус оплаты и т.д.). Builder позволяет создавать заказы пошагово, делая код более читаемым и избегая конструкторов с большим количеством параметров.

**Пример использования**:
```csharp
var order = builder
    .AddItem(combo)
    .AddItem(potato)
    .SetAddress("ул. Ленина, д. 10")
    .SetPaid(true)
    .Build();
```

### 2. Strategy (Стратегия)
**Файлы**: `Patterns/Strategy/*`

**Назначение**: Расчет итоговой стоимости заказа с различными алгоритмами для скидок, доставки и налогов.

**Обоснование**: Система должна поддерживать различные варианты расчета:
- Скидки: без скидки, процентная скидка
- Доставка: стандартная, бесплатная (при заказе > 1000), срочная
- Налоги: с НДС, без НДС

Strategy позволяет легко добавлять новые типы расчетов без изменения существующего кода. Стратегии могут возвращать 0, что исключает параметр из расчета (например, бесплатная доставка).

**Пример использования**:
```csharp
var calculator = new PriceCalculator(
    new PercentDiscountStrategy(10),
    new FreeDeliveryStrategy(1000),
    new VATTaxStrategy(20)
);
decimal total = calculator.CalculateTotal(order);
```

### 3. State (Состояние)
**Файлы**: `Patterns/State/*`

**Назначение**: Управление состоянием заказа и переходами между состояниями.

**Обоснование**: Заказ проходит через жизненный цикл: Created → Preparing → Delivering → Completed. В каждом состоянии заказ имеет определенное поведение, и переходы между состояниями должны быть контролируемыми.

**Пример использования**:
```csharp
Console.WriteLine(order.GetStateName()); // Created
order.NextState();
Console.WriteLine(order.GetStateName()); // Preparing
```

### 4. Chain of Responsibility (Цепочка обязанностей)
**Файлы**: `Patterns/Chain/*`

**Назначение**: Валидация заказа через цепочку проверок.

**Обоснование**: Перед подтверждением заказ должен пройти последовательные проверки:
1. Указан ли адрес доставки
2. Работает ли ресторан
3. Доступны ли все блюда
4. Оплачен ли заказ
5. Передача в ресторан

Каждый обработчик независим и может добавляться/удаляться без изменения других. Если одна проверка не пройдена, следующие не выполняются.

**Пример использования**:
```csharp
addressHandler
    .SetNext(restaurantHandler)
    .SetNext(availabilityHandler)
    .SetNext(paymentHandler)
    .SetNext(submitHandler);

bool result = addressHandler.Handle(order);
```

### 5. Composite (Компоновщик)
**Файлы**: `Patterns/Composite/*`

**Назначение**: Единообразная работа с простыми блюдами и комбо-наборами.

**Обоснование**: Меню содержит как отдельные блюда (Картошка, Бургер), так и составные (Комбо, включающее несколько блюд). Composite позволяет работать с ними единообразно через общий интерфейс MenuItem, рекурсивно вычислять стоимость и проверять доступность.

**Пример использования**:
```csharp
var combo = new ComboMenuItem("Комбо №1");
combo.AddItem(burger);
combo.AddItem(potato);

Console.WriteLine(combo.GetName());   // Комбо №1 (Бургер, Картошка)
Console.WriteLine(combo.GetPrice());  // 500 (сумма цен входящих блюд)
```

## Запуск проекта

```bash
cd FoodDelivery
dotnet run
```

## Функциональность

Система демонстрирует:
- Создание простых блюд и комбо-наборов
- Построение заказа с помощью Builder
- Расчет стоимости с разными стратегиями
- Валидацию заказа через цепочку проверок
- Изменение состояния заказа
- Обработку некорректных сценариев (отсутствие адреса, недоступные товары)
