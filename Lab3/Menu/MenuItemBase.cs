namespace Lab3.Menu;

public class MenuItemBase : IMenuItem
{
    public string Name { get; }
    public decimal Price { get; }
    public int Quantity { get; }

    public MenuItemBase(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public virtual bool IsAvailable()
    {
        if (Quantity > 0)
        {
            return true;
        }
        return false;
    }
}