package com.example.inventory;

import org.junit.jupiter.api.Test;

import java.util.List;

import static org.junit.jupiter.api.Assertions.assertDoesNotThrow;
import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.junit.jupiter.api.Assertions.assertTrue;

public class InventoryTrackerTest {

    @Test
    void newTrackerIsEmpty() {
        InventoryTracker inv = new InventoryTracker();
        assertEquals(0, inv.stock("A"));
        assertTrue(inv.lowStockSkus(100).isEmpty());
    }

    @Test
    void receiveCreatesSkuWithQuantity() {
        InventoryTracker inv = new InventoryTracker();
        inv.receive("A", 5);

        assertEquals(5, inv.stock("A"));
    }

    @Test
    void repeatedReceivesAccumulate() {
        InventoryTracker inv = new InventoryTracker();
        inv.receive("A", 5);
        inv.receive("A", 3);

        assertEquals(8, inv.stock("A"));
    }

    @Test
    void shipReducesStock() {
        InventoryTracker inv = new InventoryTracker();
        inv.receive("A", 5);
        inv.ship("A", 2);

        assertEquals(3, inv.stock("A"));
    }

    @Test
    void shippingDownToZeroIsAllowed() {
        InventoryTracker inv = new InventoryTracker();
        inv.receive("A", 5);

        assertDoesNotThrow(() -> inv.ship("A", 5));
        assertEquals(0, inv.stock("A"));
    }

    @Test
    void shippingMoreThanAvailableThrowsAndLeavesStockUnchanged() {
        InventoryTracker inv = new InventoryTracker();
        inv.receive("A", 5);

        assertThrows(IllegalStateException.class, () -> inv.ship("A", 10));
        assertEquals(5, inv.stock("A"));
    }

    @Test
    void shippingUnknownSkuThrows() {
        InventoryTracker inv = new InventoryTracker();

        assertThrows(IllegalStateException.class, () -> inv.ship("GHOST", 1));
    }

    @Test
    void lowStockSkusUsesExclusiveBoundary() {
        InventoryTracker inv = new InventoryTracker();
        inv.receive("A", 5); inv.ship("A", 5); // stock 0
        inv.receive("B", 4);                   // stock 4
        inv.receive("C", 5);                   // stock 5 (at threshold)
        inv.receive("D", 6);                   // stock 6

        assertEquals(List.of("A", "B"), inv.lowStockSkus(5));
    }

    @Test
    void lowStockSkusAlphabetical() {
        InventoryTracker inv = new InventoryTracker();
        inv.receive("Zeta", 1);
        inv.receive("Alpha", 1);
        inv.receive("Mu", 1);

        assertEquals(List.of("Alpha", "Mu", "Zeta"), inv.lowStockSkus(10));
    }

    @Test
    void neverReceivedSkusAreNotReported() {
        InventoryTracker inv = new InventoryTracker();
        assertTrue(inv.lowStockSkus(100).isEmpty());
    }
}
