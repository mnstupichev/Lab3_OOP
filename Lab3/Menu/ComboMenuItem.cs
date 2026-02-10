namespace Lab3.Menu;

public class ComboMenuItem : MenuItemBase
{
    private List<IMenuItem> _items;

    public ComboMenuItem(string name, decimal price, int quantity, List<IMenuItem> items) 
        : base(name, price, quantity)
    {
        _items = items;
    }

    public override bool IsAvailable()
    {
        return _items.All(item => item.IsAvailable());
    }
}