namespace Lab3.Menu;

public interface IMenuItem
{
    string Name { get; }
    decimal Price { get; }
    int Quantity { get; }
    bool IsAvailable();
}
    