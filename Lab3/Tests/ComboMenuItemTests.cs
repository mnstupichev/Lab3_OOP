using Lab3.Menu;
using Lab3.Menu.MenuItems;

namespace Lab3.Tests;

public class ComboMenuItemTests
{
    [Fact]
    public void ComboMenuItem_IsAvailable_AllItemsAvailable_ReturnsTrue()
    {
        var items = new List<IMenuItem>
        {
            new Potato(),
            new Potato()
        };
        
        var combo = new ComboMenuItem("Combo", 200, 1, items);
        
        Assert.True(combo.IsAvailable());
    }

    [Fact]
    public void ComboMenuItem_IsAvailable_OneItemUnavailable_ReturnsFalse()
    {
        var items = new List<IMenuItem>
        {
            new Potato(), 
            new Burger()
        };
        
        var combo = new ComboMenuItem("Combo", 300, 1, items);
        
        Assert.False(combo.IsAvailable());
    }
    
    [Fact]
    public void ComboMenuItem_EmptyItemsList_IsAvailableReturnsTrue()
    {
        var combo = new ComboMenuItem("Empty Combo", 0, 1, new List<IMenuItem>());

        Assert.True(combo.IsAvailable());
    }
}
