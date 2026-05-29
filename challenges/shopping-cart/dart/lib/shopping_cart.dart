/// A shopping cart that totals line items and supports a single
/// percentage-based discount code at a time.
///
/// IMPLEMENT EVERY MEMBER BELOW. Do not change the public signatures.
/// The test suite in test/shopping_cart_test.dart defines the exact
/// expected behaviour.
///
/// Example use (illustrative, not a test):
///
///     final cart = ShoppingCart();
///     cart.addItem('Apple', 1.50, 2);
///     cart.addItem('Bread', 3.00, 1);
///     cart.applyDiscountCode('SAVE10');
///     // cart.total     == 5.40   (6.00 * 0.90)
///     // cart.itemCount == 2
///
/// For an unknown discount code, throw ArgumentError.
class ShoppingCart {
  void addItem(String name, double unitPrice, int quantity) {
    throw UnimplementedError();
  }

  void removeItem(String name) {
    throw UnimplementedError();
  }

  void applyDiscountCode(String code) {
    throw UnimplementedError();
  }

  void clearDiscountCode() {
    throw UnimplementedError();
  }

  double get total => throw UnimplementedError();

  int get itemCount => throw UnimplementedError();
}
