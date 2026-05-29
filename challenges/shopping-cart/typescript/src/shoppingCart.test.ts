import { describe, expect, it } from "vitest";
import { ShoppingCart } from "./shoppingCart.js";

describe("ShoppingCart", () => {
  it("new cart is empty", () => {
    const cart = new ShoppingCart();
    expect(cart.total).toBe(0);
    expect(cart.itemCount).toBe(0);
  });

  it("adding an item sets item count and total", () => {
    const cart = new ShoppingCart();
    cart.addItem("Apple", 1.5, 2);

    expect(cart.itemCount).toBe(1);
    expect(cart.total).toBe(3.0);
  });

  it("adding two different items sums correctly", () => {
    const cart = new ShoppingCart();
    cart.addItem("Apple", 1.5, 2);
    cart.addItem("Bread", 3.0, 1);

    expect(cart.itemCount).toBe(2);
    expect(cart.total).toBe(6.0);
  });

  it("adding the same item name twice increases its quantity", () => {
    const cart = new ShoppingCart();
    cart.addItem("Apple", 1.5, 2);
    cart.addItem("Apple", 1.5, 3);

    expect(cart.itemCount).toBe(1);
    expect(cart.total).toBe(7.5);
  });

  it("removing an item by name reduces total and item count", () => {
    const cart = new ShoppingCart();
    cart.addItem("Apple", 1.5, 2);
    cart.addItem("Bread", 3.0, 1);

    cart.removeItem("Apple");

    expect(cart.itemCount).toBe(1);
    expect(cart.total).toBe(3.0);
  });

  it("removing an item that isn't in the cart is a no-op", () => {
    const cart = new ShoppingCart();
    cart.addItem("Apple", 1.5, 2);

    expect(() => cart.removeItem("Ghost")).not.toThrow();
    expect(cart.itemCount).toBe(1);
    expect(cart.total).toBe(3.0);
  });

  it("applying SAVE10 takes 10% off", () => {
    const cart = new ShoppingCart();
    cart.addItem("Widget", 100.0, 1);
    cart.applyDiscountCode("SAVE10");

    expect(cart.total).toBe(90.0);
  });

  it("a new discount code replaces the previously-active one", () => {
    const cart = new ShoppingCart();
    cart.addItem("Widget", 10.0, 1);

    cart.applyDiscountCode("HALFOFF");
    expect(cart.total).toBe(5.0);

    cart.applyDiscountCode("SAVE20");
    expect(cart.total).toBe(8.0);
  });

  it("applying an unknown code throws and keeps the existing code", () => {
    const cart = new ShoppingCart();
    cart.addItem("Widget", 100.0, 1);
    cart.applyDiscountCode("SAVE10");

    expect(() => cart.applyDiscountCode("BOGUS")).toThrow();

    // SAVE10 must still be in effect.
    expect(cart.total).toBe(90.0);
  });

  it("total rounds to 2 decimal places", () => {
    const cart = new ShoppingCart();
    cart.addItem("Widget", 9.99, 1);
    cart.applyDiscountCode("SAVE10");

    // 9.99 * 0.9 = 8.991 -> rounds to 8.99.
    expect(cart.total).toBe(8.99);
  });
});
