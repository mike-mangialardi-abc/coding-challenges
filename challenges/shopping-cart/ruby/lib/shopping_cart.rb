# A shopping cart that totals line items and supports a single
# percentage-based discount code at a time.
#
# IMPLEMENT EVERY METHOD BELOW. Do not change the public signatures.
# The test suite in spec/shopping_cart_spec.rb defines the exact expected
# behaviour.
#
# Example use (illustrative, not a test):
#
#   cart = ShoppingCart.new
#   cart.add_item("Apple", 1.50, 2)
#   cart.add_item("Bread", 3.00, 1)
#   cart.apply_discount_code("SAVE10")
#   # cart.total       => 5.40   (6.00 * 0.90)
#   # cart.item_count  => 2
#
# For an unknown discount code, raise ArgumentError.
class ShoppingCart
  def initialize
    raise NotImplementedError
  end

  def add_item(name, unit_price, quantity)
    raise NotImplementedError
  end

  def remove_item(name)
    raise NotImplementedError
  end

  def apply_discount_code(code)
    raise NotImplementedError
  end

  def clear_discount_code
    raise NotImplementedError
  end

  def total
    raise NotImplementedError
  end

  def item_count
    raise NotImplementedError
  end
end
