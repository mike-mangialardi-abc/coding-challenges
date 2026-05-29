package com.example.shoppingcart;

import org.junit.jupiter.api.Test;

import java.math.BigDecimal;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertDoesNotThrow;
import static org.junit.jupiter.api.Assertions.assertThrows;

public class ShoppingCartTest {

    private static BigDecimal money(String value) {
        return new BigDecimal(value);
    }

    @Test
    void newCartIsEmpty() {
        ShoppingCart cart = new ShoppingCart();
        assertEquals(0, cart.getItemCount());
        assertEquals(0, money("0.00").compareTo(cart.getTotal()));
    }

    @Test
    void addingItemSetsCountAndTotal() {
        ShoppingCart cart = new ShoppingCart();
        cart.addItem("Apple", money("1.50"), 2);

        assertEquals(1, cart.getItemCount());
        assertEquals(0, money("3.00").compareTo(cart.getTotal()));
    }

    @Test
    void addingTwoDifferentItemsSumsCorrectly() {
        ShoppingCart cart = new ShoppingCart();
        cart.addItem("Apple", money("1.50"), 2);
        cart.addItem("Bread", money("3.00"), 1);

        assertEquals(2, cart.getItemCount());
        assertEquals(0, money("6.00").compareTo(cart.getTotal()));
    }

    @Test
    void addingSameNameTwiceIncreasesQuantity() {
        ShoppingCart cart = new ShoppingCart();
        cart.addItem("Apple", money("1.50"), 2);
        cart.addItem("Apple", money("1.50"), 3);

        assertEquals(1, cart.getItemCount());
        assertEquals(0, money("7.50").compareTo(cart.getTotal()));
    }

    @Test
    void removingItemReducesCountAndTotal() {
        ShoppingCart cart = new ShoppingCart();
        cart.addItem("Apple", money("1.50"), 2);
        cart.addItem("Bread", money("3.00"), 1);

        cart.removeItem("Apple");

        assertEquals(1, cart.getItemCount());
        assertEquals(0, money("3.00").compareTo(cart.getTotal()));
    }

    @Test
    void removingMissingItemIsNoOp() {
        ShoppingCart cart = new ShoppingCart();
        cart.addItem("Apple", money("1.50"), 2);

        assertDoesNotThrow(() -> cart.removeItem("Ghost"));

        assertEquals(1, cart.getItemCount());
        assertEquals(0, money("3.00").compareTo(cart.getTotal()));
    }

    @Test
    void save10TakesTenPercentOff() {
        ShoppingCart cart = new ShoppingCart();
        cart.addItem("Widget", money("100.00"), 1);
        cart.applyDiscountCode("SAVE10");

        assertEquals(0, money("90.00").compareTo(cart.getTotal()));
    }

    @Test
    void newCodeReplacesPrevious() {
        ShoppingCart cart = new ShoppingCart();
        cart.addItem("Widget", money("10.00"), 1);

        cart.applyDiscountCode("HALFOFF");
        assertEquals(0, money("5.00").compareTo(cart.getTotal()));

        cart.applyDiscountCode("SAVE20");
        assertEquals(0, money("8.00").compareTo(cart.getTotal()));
    }

    @Test
    void unknownCodeThrowsAndKeepsExistingCode() {
        ShoppingCart cart = new ShoppingCart();
        cart.addItem("Widget", money("100.00"), 1);
        cart.applyDiscountCode("SAVE10");

        assertThrows(IllegalArgumentException.class,
                () -> cart.applyDiscountCode("BOGUS"));

        // SAVE10 must still be in effect.
        assertEquals(0, money("90.00").compareTo(cart.getTotal()));
    }

    @Test
    void totalRoundsToTwoDecimals() {
        ShoppingCart cart = new ShoppingCart();
        cart.addItem("Widget", money("9.99"), 1);
        cart.applyDiscountCode("SAVE10");

        // 9.99 * 0.9 = 8.991 -> rounds to 8.99.
        assertEquals(0, money("8.99").compareTo(cart.getTotal()));
    }
}
