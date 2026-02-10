using Lab3.Menu.MenuItems;

namespace Lab3.Tests;

public class MenuItemTests
{
    [Fact]
    public void MenuItemBase_Constructor_SetsProperties()
    {
        var item = new Potato();
        
        Assert.Equal("Potato", item.Name);
        Assert.Equal(100, item.Price);
        Assert.Equal(1, item.Quantity);
    }

    [Fact]
    public void MenuItemBase_IsAvailable_ReturnsTrueWhenQuantityPositive()
    {
        var item = new Potato();
        
        Assert.True(item.IsAvailable());
    }

    [Fact]
    public void MenuItemBase_IsAvailable_ReturnsFalseWhenQuantityZero()
    {
        var item = new Burger();
        
        Assert.False(item.IsAvailable());
    }
}
