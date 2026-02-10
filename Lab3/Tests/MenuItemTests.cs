using Lab3.Menu;

namespace Lab3.Tests;

public class MenuItemTests
{
    [Fact]
    public void MenuItemBuilder_GetName_ReturnsName()
    {
        var item = new MenuItemBase("Pizza", 500m);
            
        Assert.Equal("Pizza", item.GetName());
    }

    [Fact]
    public void MenuItemBuilder_GetPrice_ReturnsPrice()
    {
        var item = new MenuItemBase("Pizza", 500m);
            
        Assert.Equal(500m, item.GetPrice());
    }

    [Fact]
    public void MenuItemBuilder_IsAvailable_DefaultTrue()
    {
        var item = new MenuItemBase("Pizza", 500m);
            
        Assert.True(item.IsAvailable());
    }

    [Fact]
    public void MenuItemBuilder_SetAvailable_ChangesAvailability()
    {
        var item = new MenuItemBase("Pizza", 500m, true);
            
        item.SetAvailable(false);
            
        Assert.False(item.IsAvailable());
    }

    [Fact]
    public void ComboMenuItem_AddItem_AddsItem()
    {
        var combo = new ComboMenuItem("Lunch Combo");
        var pizza = new MenuItemBase("Pizza", 500m);
        var drink = new MenuItemBase("Cola", 100m);
            
        combo.AddItem(pizza);
        combo.AddItem(drink);
            
        Assert.Equal(600m, combo.GetPrice());
    }

    [Fact]
    public void ComboMenuItem_GetName_IncludesAllItems()
    {
        var combo = new ComboMenuItem("Lunch Combo");
        combo.AddItem(new MenuItemBase("Pizza", 500m));
        combo.AddItem(new MenuItemBase("Cola", 100m));
            
        var name = combo.GetName();
            
        Assert.Contains("Lunch Combo", name);
        Assert.Contains("Pizza", name);
        Assert.Contains("Cola", name);
    }

    [Fact]
    public void ComboMenuItem_GetPrice_SumsPrices()
    {
        var combo = new ComboMenuItem("Combo");
        combo.AddItem(new MenuItemBase("Item1", 200m));
        combo.AddItem(new MenuItemBase("Item2", 300m));
        combo.AddItem(new MenuItemBase("Item3", 150m));
            
        Assert.Equal(650m, combo.GetPrice());
    }

    [Fact]
    public void ComboMenuItem_IsAvailable_AllItemsAvailable_ReturnsTrue()
    {
        var combo = new ComboMenuItem("Combo");
        combo.AddItem(new MenuItemBase("Item1", 200m, true));
        combo.AddItem(new MenuItemBase("Item2", 300m, true));
            
        Assert.True(combo.IsAvailable());
    }

    [Fact]
    public void ComboMenuItem_IsAvailable_OneItemUnavailable_ReturnsFalse()
    {
        var combo = new ComboMenuItem("Combo");
        combo.AddItem(new MenuItemBase("Item1", 200m, true));
        combo.AddItem(new MenuItemBase("Item2", 300m, false));
            
        Assert.False(combo.IsAvailable());
    }

    [Fact]
    public void ComboMenuItem_RemoveItem_RemovesItem()
    {
        var combo = new ComboMenuItem("Combo");
        var item1 = new MenuItemBase("Item1", 200m);
        var item2 = new MenuItemBase("Item2", 300m);
            
        combo.AddItem(item1);
        combo.AddItem(item2);
        combo.RemoveItem(item1);
            
        Assert.Equal(300m, combo.GetPrice());
    }
}