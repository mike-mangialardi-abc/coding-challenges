/**
 * Tracks on-hand quantity per SKU and answers low-stock queries.
 *
 * IMPLEMENT EVERY MEMBER BELOW. Do not change the public signatures.
 * The test suite in inventoryTracker.test.ts defines the exact expected behaviour.
 *
 * Example use (illustrative, not a test):
 *
 *     const inv = new InventoryTracker();
 *     inv.receive("WIDGET", 10);
 *     inv.ship("WIDGET", 3);
 *     // inv.stock("WIDGET") === 7
 *     // inv.lowStockSkus(8) contains "WIDGET"
 *
 * For invalid ship operations (unknown SKU, or shipping more than is in stock),
 * throw `new Error(...)`.
 */
export class InventoryTracker {
  receive(sku: string, quantity: number): void {
    throw new Error("Not implemented");
  }

  ship(sku: string, quantity: number): void {
    throw new Error("Not implemented");
  }

  stock(sku: string): number {
    throw new Error("Not implemented");
  }

  lowStockSkus(threshold: number): string[] {
    throw new Error("Not implemented");
  }
}
