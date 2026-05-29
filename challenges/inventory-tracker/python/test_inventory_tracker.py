import pytest

from inventory_tracker import InventoryTracker


def test_new_tracker_is_empty():
    inv = InventoryTracker()
    assert inv.stock("A") == 0
    assert inv.low_stock_skus(100) == []


def test_receive_creates_sku_with_quantity():
    inv = InventoryTracker()
    inv.receive("A", 5)

    assert inv.stock("A") == 5


def test_receive_accumulates():
    inv = InventoryTracker()
    inv.receive("A", 5)
    inv.receive("A", 3)

    assert inv.stock("A") == 8


def test_ship_reduces_stock():
    inv = InventoryTracker()
    inv.receive("A", 5)
    inv.ship("A", 2)

    assert inv.stock("A") == 3


def test_ship_down_to_zero_is_allowed():
    inv = InventoryTracker()
    inv.receive("A", 5)
    inv.ship("A", 5)  # must not raise

    assert inv.stock("A") == 0


def test_ship_more_than_available_raises_and_leaves_stock_unchanged():
    inv = InventoryTracker()
    inv.receive("A", 5)

    with pytest.raises(ValueError):
        inv.ship("A", 10)

    assert inv.stock("A") == 5


def test_ship_unknown_sku_raises():
    inv = InventoryTracker()

    with pytest.raises(ValueError):
        inv.ship("GHOST", 1)


def test_low_stock_skus_exclusive_boundary():
    inv = InventoryTracker()
    inv.receive("A", 5); inv.ship("A", 5)  # stock 0
    inv.receive("B", 4)                    # stock 4
    inv.receive("C", 5)                    # stock 5 (at threshold, excluded)
    inv.receive("D", 6)                    # stock 6 (above threshold)

    assert inv.low_stock_skus(5) == ["A", "B"]


def test_low_stock_skus_alphabetical():
    inv = InventoryTracker()
    inv.receive("Zeta", 1)
    inv.receive("Alpha", 1)
    inv.receive("Mu", 1)

    assert inv.low_stock_skus(10) == ["Alpha", "Mu", "Zeta"]


def test_never_received_skus_not_reported():
    inv = InventoryTracker()
    assert inv.low_stock_skus(100) == []
