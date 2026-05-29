import { describe, expect, it } from "vitest";
import { InventoryTracker } from "./inventoryTracker.js";

describe("InventoryTracker", () => {
  it("new tracker is empty", () => {
    const inv = new InventoryTracker();
    expect(inv.stock("A")).toBe(0);
    expect(inv.lowStockSkus(100)).toEqual([]);
  });

  it("receive creates a SKU with the given quantity", () => {
    const inv = new InventoryTracker();
    inv.receive("A", 5);

    expect(inv.stock("A")).toBe(5);
  });

  it("repeated receives accumulate", () => {
    const inv = new InventoryTracker();
    inv.receive("A", 5);
    inv.receive("A", 3);

    expect(inv.stock("A")).toBe(8);
  });

  it("ship reduces stock", () => {
    const inv = new InventoryTracker();
    inv.receive("A", 5);
    inv.ship("A", 2);

    expect(inv.stock("A")).toBe(3);
  });

  it("shipping down to exactly zero is allowed", () => {
    const inv = new InventoryTracker();
    inv.receive("A", 5);

    expect(() => inv.ship("A", 5)).not.toThrow();
    expect(inv.stock("A")).toBe(0);
  });

  it("shipping more than available throws and leaves stock unchanged", () => {
    const inv = new InventoryTracker();
    inv.receive("A", 5);

    expect(() => inv.ship("A", 10)).toThrow();
    expect(inv.stock("A")).toBe(5);
  });

  it("shipping an unknown SKU throws and does not create the SKU", () => {
    const inv = new InventoryTracker();
    inv.receive("A", 3);

    expect(() => inv.ship("GHOST", 1)).toThrow();
    // The unknown SKU must NOT have been silently created at stock 0
    // (it must remain "never tracked", which lowStockSkus also ignores).
    expect(inv.lowStockSkus(1)).toEqual([]);
    expect(inv.stock("A")).toBe(3);
  });

  it("lowStockSkus uses a strictly-less-than boundary", () => {
    const inv = new InventoryTracker();
    inv.receive("A", 5); inv.ship("A", 5); // stock 0
    inv.receive("B", 4);                   // stock 4
    inv.receive("C", 5);                   // stock 5 (at threshold, excluded)
    inv.receive("D", 6);                   // stock 6 (above threshold)

    expect(inv.lowStockSkus(5)).toEqual(["A", "B"]);
  });

  it("lowStockSkus returns SKUs in alphabetical order", () => {
    const inv = new InventoryTracker();
    inv.receive("Zeta", 1);
    inv.receive("Alpha", 1);
    inv.receive("Mu", 1);

    expect(inv.lowStockSkus(10)).toEqual(["Alpha", "Mu", "Zeta"]);
  });

  it("never-received SKUs are not reported", () => {
    const inv = new InventoryTracker();
    expect(inv.lowStockSkus(100)).toEqual([]);
  });
});
