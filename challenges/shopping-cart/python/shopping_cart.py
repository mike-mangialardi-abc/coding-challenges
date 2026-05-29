"""A shopping cart that totals line items and supports a single
percentage-based discount code at a time.

IMPLEMENT EVERY METHOD/PROPERTY BELOW. Do not change the public signatures.
The test suite in test_shopping_cart.py defines the exact expected behaviour.

Example use (illustrative, not a test):

    cart = ShoppingCart()
    cart.add_item("Apple", 1.50, 2)
    cart.add_item("Bread", 3.00, 1)
    cart.apply_discount_code("SAVE10")
    # cart.total == 5.40   (6.00 * 0.90)
    # cart.item_count == 2

For an unknown discount code, raise ValueError.
"""


class ShoppingCart:
    def __init__(self):
        raise NotImplementedError

    def add_item(self, name, unit_price, quantity):
        raise NotImplementedError

    def remove_item(self, name):
        raise NotImplementedError

    def apply_discount_code(self, code):
        raise NotImplementedError

    def clear_discount_code(self):
        raise NotImplementedError

    @property
    def total(self):
        raise NotImplementedError

    @property
    def item_count(self):
        raise NotImplementedError
