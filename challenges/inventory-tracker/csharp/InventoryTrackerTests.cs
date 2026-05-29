using Xunit;

namespace InventoryTrackerChallenge;

public class InventoryTrackerTests
{
    [Fact]
    public void NewTracker_IsEmpty()
    {
        var inv = new InventoryTracker();
        Assert.Equal(0, inv.Stock("A"));
        Assert.Empty(inv.LowStockSkus(100));
    }

    [Fact]
    public void Receive_CreatesSkuWithQuantity()
    {
        var inv = new InventoryTracker();
        inv.Receive("A", 5);

        Assert.Equal(5, inv.Stock("A"));
    }

    [Fact]
    public void Receive_RepeatedAccumulates()
    {
        var inv = new InventoryTracker();
        inv.Receive("A", 5);
        inv.Receive("A", 3);

        Assert.Equal(8, inv.Stock("A"));
    }

    [Fact]
    public void Ship_ReducesStock()
    {
        var inv = new InventoryTracker();
        inv.Receive("A", 5);
        inv.Ship("A", 2);

        Assert.Equal(3, inv.Stock("A"));
    }

    [Fact]
    public void Ship_DownToZero_IsAllowed()
    {
        var inv = new InventoryTracker();
        inv.Receive("A", 5);
        inv.Ship("A", 5);

        Assert.Equal(0, inv.Stock("A"));
    }

    [Fact]
    public void Ship_MoreThanAvailable_ThrowsAndLeavesStockUnchanged()
    {
        var inv = new InventoryTracker();
        inv.Receive("A", 5);

        Assert.Throws<InvalidOperationException>(() => inv.Ship("A", 10));
        Assert.Equal(5, inv.Stock("A"));
    }

    [Fact]
    public void Ship_UnknownSku_Throws()
    {
        var inv = new InventoryTracker();

        Assert.Throws<InvalidOperationException>(() => inv.Ship("GHOST", 1));
    }

    [Fact]
    public void LowStockSkus_ExclusiveBoundary()
    {
        var inv = new InventoryTracker();
        inv.Receive("A", 5); inv.Ship("A", 5); // stock 0
        inv.Receive("B", 4);                   // stock 4
        inv.Receive("C", 5);                   // stock 5  (at threshold, excluded)
        inv.Receive("D", 6);                   // stock 6  (above threshold)

        var result = inv.LowStockSkus(5);

        Assert.Equal(new[] { "A", "B" }, result);
    }

    [Fact]
    public void LowStockSkus_ReturnsAlphabeticalOrder()
    {
        var inv = new InventoryTracker();
        inv.Receive("Zeta", 1);
        inv.Receive("Alpha", 1);
        inv.Receive("Mu", 1);

        var result = inv.LowStockSkus(10);

        Assert.Equal(new[] { "Alpha", "Mu", "Zeta" }, result);
    }

    [Fact]
    public void LowStockSkus_NeverReceivedSkusAreNotReported()
    {
        var inv = new InventoryTracker();
        // No SKUs received.

        Assert.Empty(inv.LowStockSkus(100));
    }
}
