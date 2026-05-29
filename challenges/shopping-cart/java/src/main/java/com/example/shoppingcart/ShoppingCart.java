package com.example.shoppingcart;

import java.math.BigDecimal;

/**
 * A shopping cart that totals line items and supports a single
 * percentage-based discount code at a time.
 *
 * IMPLEMENT EVERY METHOD BELOW. Do not change the public signatures.
 * The test suite in ShoppingCartTest.java defines the exact expected behaviour.
 *
 * Example use (illustrative, not a test):
 *
 *     ShoppingCart cart = new ShoppingCart();
 *     cart.addItem("Apple", new BigDecimal("1.50"), 2);
 *     cart.addItem("Bread", new BigDecimal("3.00"), 1);
 *     cart.applyDiscountCode("SAVE10");
 *     // cart.getTotal() equals new BigDecimal("5.40")  (6.00 * 0.90)
 *     // cart.getItemCount() == 2
 *
 * For an unknown discount code, throw IllegalArgumentException.
 *
 * Totals must be returned as a BigDecimal with scale 2.
 */
public class ShoppingCart {

    public void addItem(String name, BigDecimal unitPrice, int quantity) {
        throw new UnsupportedOperationException("Not implemented");
    }

    public void removeItem(String name) {
        throw new UnsupportedOperationException("Not implemented");
    }

    public void applyDiscountCode(String code) {
        throw new UnsupportedOperationException("Not implemented");
    }

    public void clearDiscountCode() {
        throw new UnsupportedOperationException("Not implemented");
    }

    public BigDecimal getTotal() {
        throw new UnsupportedOperationException("Not implemented");
    }

    public int getItemCount() {
        throw new UnsupportedOperationException("Not implemented");
    }
}
