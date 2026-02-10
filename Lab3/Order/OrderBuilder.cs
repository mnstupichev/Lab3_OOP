using Lab3.Menu;

namespace Lab3.Order;

public class OrderBuilder
{
    private string _address;
    private bool _paid;
    private List<IMenuItem> _menuItems = new();

    public OrderBuilder WithAddress(string address)
    {
        _address = address;
        return this;
    }

    public OrderBuilder WithPaid(bool paid)
    {
        _paid = paid;
        return this;
    }

    public OrderBuilder AddItem(IMenuItem item)
    {
        _menuItems.Add(item);
        return this;
    }

    public Order Build()
    {
        return new Order(_address, _paid,  _menuItems);
    }
}