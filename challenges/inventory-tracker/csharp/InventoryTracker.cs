namespace InventoryTrackerChallenge;

/// <summary>
/// Tracks on-hand quantity per SKU and answers low-stock queries.
///
/// IMPLEMENT EVERY MEMBER BELOW. Do not change the public signatures.
/// The test suite in InventoryTrackerTests.cs defines the exact expected behaviour.
///
/// Example use (illustrative, not a test):
///
///     var inv = new InventoryTracker();
///     inv.Receive("WIDGET", 10);
///     inv.Ship("WIDGET", 3);
///     // inv.Stock("WIDGET") == 7
///     // inv.LowStockSkus(8) contains "WIDGET"
///
/// For invalid Ship operations (unknown SKU, or shipping more than is in stock),
/// throw <see cref="InvalidOperationException"/>.
/// </summary>
public class InventoryTracker
{
    public void Receive(string sku, int quantity)
    {
        throw new NotImplementedException();
    }

    public void Ship(string sku, int quantity)
    {
        throw new NotImplementedException();
    }

    public int Stock(string sku)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<string> LowStockSkus(int threshold)
    {
        throw new NotImplementedException();
    }
}
