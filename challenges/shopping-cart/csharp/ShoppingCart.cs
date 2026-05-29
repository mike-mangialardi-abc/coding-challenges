namespace ShoppingCartChallenge;

/// <summary>
/// A shopping cart that totals line items and supports a single percentage-based
/// discount code at a time.
///
/// IMPLEMENT EVERY MEMBER BELOW. Do not change the public signatures.
/// The test suite in ShoppingCartTests.cs defines the exact expected behaviour.
///
/// Example use (this is illustrative, not a test):
///
///     var cart = new ShoppingCart();
///     cart.AddItem("Apple", 1.50m, 2);
///     cart.AddItem("Bread", 3.00m, 1);
///     cart.ApplyDiscountCode("SAVE10");
///     // cart.Total is 5.40m (6.00 * 0.90)
///     // cart.ItemCount is 2
///
/// For an unknown discount code, throw <see cref="ArgumentException"/>.
/// </summary>
public class ShoppingCart
{
    public void AddItem(string name, decimal unitPrice, int quantity)
    {
        throw new NotImplementedException();
    }

    public void RemoveItem(string name)
    {
        throw new NotImplementedException();
    }

    public void ApplyDiscountCode(string code)
    {
        throw new NotImplementedException();
    }

    public void ClearDiscountCode()
    {
        throw new NotImplementedException();
    }

    public decimal Total => throw new NotImplementedException();

    public int ItemCount => throw new NotImplementedException();
}
