using Xunit;

namespace ShoppingCartChallenge;

public class ShoppingCartTests
{
    [Fact]
    public void NewCart_IsEmpty()
    {
        var cart = new ShoppingCart();
        Assert.Equal(0m, cart.Total);
        Assert.Equal(0, cart.ItemCount);
    }

    [Fact]
    public void AddItem_SetsItemCountAndTotal()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Apple", 1.50m, 2);

        Assert.Equal(1, cart.ItemCount);
        Assert.Equal(3.00m, cart.Total);
    }

    [Fact]
    public void AddItem_TwoDifferentItems_SumsCorrectly()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Apple", 1.50m, 2);
        cart.AddItem("Bread", 3.00m, 1);

        Assert.Equal(2, cart.ItemCount);
        Assert.Equal(6.00m, cart.Total);
    }

    [Fact]
    public void AddItem_SameNameTwice_IncreasesQuantity()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Apple", 1.50m, 2);
        cart.AddItem("Apple", 1.50m, 3);

        Assert.Equal(1, cart.ItemCount);
        Assert.Equal(7.50m, cart.Total);
    }

    [Fact]
    public void RemoveItem_RemovesFromCart()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Apple", 1.50m, 2);
        cart.AddItem("Bread", 3.00m, 1);

        cart.RemoveItem("Apple");

        Assert.Equal(1, cart.ItemCount);
        Assert.Equal(3.00m, cart.Total);
    }

    [Fact]
    public void RemoveItem_NotInCart_IsNoOp()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Apple", 1.50m, 2);

        cart.RemoveItem("Ghost"); // should not throw

        Assert.Equal(1, cart.ItemCount);
        Assert.Equal(3.00m, cart.Total);
    }

    [Fact]
    public void ApplyDiscountCode_Save10_TakesTenPercentOff()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Widget", 100.00m, 1);
        cart.ApplyDiscountCode("SAVE10");

        Assert.Equal(90.00m, cart.Total);
    }

    [Fact]
    public void ApplyDiscountCode_NewCodeReplacesPrevious()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Widget", 10.00m, 1);

        cart.ApplyDiscountCode("HALFOFF");
        Assert.Equal(5.00m, cart.Total);

        cart.ApplyDiscountCode("SAVE20");
        Assert.Equal(8.00m, cart.Total);
    }

    [Fact]
    public void ApplyDiscountCode_Unknown_ThrowsAndKeepsExistingCode()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Widget", 100.00m, 1);
        cart.ApplyDiscountCode("SAVE10");

        Assert.Throws<ArgumentException>(() => cart.ApplyDiscountCode("BOGUS"));

        // The previously-active SAVE10 must still be in effect.
        Assert.Equal(90.00m, cart.Total);
    }

    [Fact]
    public void Total_RoundsToTwoDecimals()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Widget", 9.99m, 1);
        cart.ApplyDiscountCode("SAVE10");

        // 9.99 * 0.9 = 8.991 -> rounds to 8.99.
        Assert.Equal(8.99m, cart.Total);
    }
}
