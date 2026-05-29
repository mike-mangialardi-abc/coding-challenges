import pytest

from shopping_cart import ShoppingCart


def test_new_cart_is_empty():
    cart = ShoppingCart()
    assert cart.total == 0
    assert cart.item_count == 0


def test_adding_item_sets_count_and_total():
    cart = ShoppingCart()
    cart.add_item("Apple", 1.50, 2)

    assert cart.item_count == 1
    assert cart.total == 3.00


def test_adding_two_different_items_sums_correctly():
    cart = ShoppingCart()
    cart.add_item("Apple", 1.50, 2)
    cart.add_item("Bread", 3.00, 1)

    assert cart.item_count == 2
    assert cart.total == 6.00


def test_adding_same_name_twice_increases_quantity():
    cart = ShoppingCart()
    cart.add_item("Apple", 1.50, 2)
    cart.add_item("Apple", 1.50, 3)

    assert cart.item_count == 1
    assert cart.total == 7.50


def test_removing_item_reduces_total_and_count():
    cart = ShoppingCart()
    cart.add_item("Apple", 1.50, 2)
    cart.add_item("Bread", 3.00, 1)

    cart.remove_item("Apple")

    assert cart.item_count == 1
    assert cart.total == 3.00


def test_removing_missing_item_is_noop():
    cart = ShoppingCart()
    cart.add_item("Apple", 1.50, 2)

    cart.remove_item("Ghost")  # must not raise

    assert cart.item_count == 1
    assert cart.total == 3.00


def test_save10_takes_ten_percent_off():
    cart = ShoppingCart()
    cart.add_item("Widget", 100.00, 1)
    cart.apply_discount_code("SAVE10")

    assert cart.total == 90.00


def test_new_code_replaces_previous():
    cart = ShoppingCart()
    cart.add_item("Widget", 10.00, 1)

    cart.apply_discount_code("HALFOFF")
    assert cart.total == 5.00

    cart.apply_discount_code("SAVE20")
    assert cart.total == 8.00


def test_unknown_code_raises_and_keeps_existing_code():
    cart = ShoppingCart()
    cart.add_item("Widget", 100.00, 1)
    cart.apply_discount_code("SAVE10")

    with pytest.raises(ValueError):
        cart.apply_discount_code("BOGUS")

    # SAVE10 must still be in effect.
    assert cart.total == 90.00


def test_total_rounds_to_two_decimals():
    cart = ShoppingCart()
    cart.add_item("Widget", 9.99, 1)
    cart.apply_discount_code("SAVE10")

    # 9.99 * 0.9 = 8.991 -> rounds to 8.99.
    assert cart.total == 8.99
