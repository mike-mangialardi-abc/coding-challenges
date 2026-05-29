"""Tracks on-hand quantity per SKU and answers low-stock queries.

IMPLEMENT EVERY METHOD BELOW. Do not change the public signatures.
The test suite in test_inventory_tracker.py defines the exact expected
behaviour.

Example use (illustrative, not a test):

    inv = InventoryTracker()
    inv.receive("WIDGET", 10)
    inv.ship("WIDGET", 3)
    # inv.stock("WIDGET") == 7
    # inv.low_stock_skus(8) contains "WIDGET"

For invalid ship operations (unknown SKU, or shipping more than is in stock),
raise ValueError.
"""


class InventoryTracker:
    def __init__(self):
        raise NotImplementedError

    def receive(self, sku, quantity):
        raise NotImplementedError

    def ship(self, sku, quantity):
        raise NotImplementedError

    def stock(self, sku):
        raise NotImplementedError

    def low_stock_skus(self, threshold):
        raise NotImplementedError
