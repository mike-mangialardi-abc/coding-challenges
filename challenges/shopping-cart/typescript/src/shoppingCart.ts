/**
 * A shopping cart that totals line items and supports a single percentage-based
 * discount code at a time.
 *
 * IMPLEMENT EVERY MEMBER BELOW. Do not change the public signatures.
 * The test suite in shoppingCart.test.ts defines the exact expected behaviour.
 *
 * Example use (illustrative, not a test):
 *
 *     const cart = new ShoppingCart();
 *     cart.addItem("Apple", 1.50, 2);
 *     cart.addItem("Bread", 3.00, 1);
 *     cart.applyDiscountCode("SAVE10");
 *     // cart.total === 5.40  (6.00 * 0.90)
 *     // cart.itemCount === 2
 *
 * For an unknown discount code, throw `new Error(...)`.
 */
export class ShoppingCart {
  addItem(name: string, unitPrice: number, quantity: number): void {
    throw new Error("Not implemented");
  }

  removeItem(name: string): void {
    throw new Error("Not implemented");
  }

  applyDiscountCode(code: string): void {
    throw new Error("Not implemented");
  }

  clearDiscountCode(): void {
    throw new Error("Not implemented");
  }

  get total(): number {
    throw new Error("Not implemented");
  }

  get itemCount(): number {
    throw new Error("Not implemented");
  }
}
