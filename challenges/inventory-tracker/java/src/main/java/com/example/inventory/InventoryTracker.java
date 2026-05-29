package com.example.inventory;

import java.util.List;

/**
 * Tracks on-hand quantity per SKU and answers low-stock queries.
 *
 * IMPLEMENT EVERY METHOD BELOW. Do not change the public signatures.
 * The test suite in InventoryTrackerTest.java defines the exact expected behaviour.
 *
 * Example use (illustrative, not a test):
 *
 *     InventoryTracker inv = new InventoryTracker();
 *     inv.receive("WIDGET", 10);
 *     inv.ship("WIDGET", 3);
 *     // inv.stock("WIDGET") == 7
 *     // inv.lowStockSkus(8) contains "WIDGET"
 *
 * For invalid ship operations (unknown SKU, or shipping more than is in stock),
 * throw IllegalStateException.
 */
public class InventoryTracker {

    public void receive(String sku, int quantity) {
        throw new UnsupportedOperationException("Not implemented");
    }

    public void ship(String sku, int quantity) {
        throw new UnsupportedOperationException("Not implemented");
    }

    public int stock(String sku) {
        throw new UnsupportedOperationException("Not implemented");
    }

    public List<String> lowStockSkus(int threshold) {
        throw new UnsupportedOperationException("Not implemented");
    }
}
