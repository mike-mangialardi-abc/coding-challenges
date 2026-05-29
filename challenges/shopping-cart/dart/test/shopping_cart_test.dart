import 'package:test/test.dart';
import 'package:shopping_cart_challenge/shopping_cart.dart';

void main() {
  test('new cart is empty', () {
    final cart = ShoppingCart();
    expect(cart.total, 0);
    expect(cart.itemCount, 0);
  });

  test('adding an item sets item count and total', () {
    final cart = ShoppingCart();
    cart.addItem('Apple', 1.50, 2);

    expect(cart.itemCount, 1);
    expect(cart.total, 3.00);
  });

  test('adding two different items sums correctly', () {
    final cart = ShoppingCart();
    cart.addItem('Apple', 1.50, 2);
    cart.addItem('Bread', 3.00, 1);

    expect(cart.itemCount, 2);
    expect(cart.total, 6.00);
  });

  test('adding the same item name twice increases its quantity', () {
    final cart = ShoppingCart();
    cart.addItem('Apple', 1.50, 2);
    cart.addItem('Apple', 1.50, 3);

    expect(cart.itemCount, 1);
    expect(cart.total, 7.50);
  });

  test('removing an item reduces total and count', () {
    final cart = ShoppingCart();
    cart.addItem('Apple', 1.50, 2);
    cart.addItem('Bread', 3.00, 1);

    cart.removeItem('Apple');

    expect(cart.itemCount, 1);
    expect(cart.total, 3.00);
  });

  test('removing a missing item is a no-op', () {
    final cart = ShoppingCart();
    cart.addItem('Apple', 1.50, 2);

    expect(() => cart.removeItem('Ghost'), returnsNormally);
    expect(cart.itemCount, 1);
    expect(cart.total, 3.00);
  });

  test('SAVE10 takes 10% off', () {
    final cart = ShoppingCart();
    cart.addItem('Widget', 100.00, 1);
    cart.applyDiscountCode('SAVE10');

    expect(cart.total, 90.00);
  });

  test('a new discount code replaces the previous one', () {
    final cart = ShoppingCart();
    cart.addItem('Widget', 10.00, 1);

    cart.applyDiscountCode('HALFOFF');
    expect(cart.total, 5.00);

    cart.applyDiscountCode('SAVE20');
    expect(cart.total, 8.00);
  });

  test('unknown code throws and keeps the existing code', () {
    final cart = ShoppingCart();
    cart.addItem('Widget', 100.00, 1);
    cart.applyDiscountCode('SAVE10');

    expect(() => cart.applyDiscountCode('BOGUS'), throwsArgumentError);

    // SAVE10 must still be in effect.
    expect(cart.total, 90.00);
  });

  test('total rounds to 2 decimal places', () {
    final cart = ShoppingCart();
    cart.addItem('Widget', 9.99, 1);
    cart.applyDiscountCode('SAVE10');

    // 9.99 * 0.9 = 8.991 -> rounds to 8.99.
    expect(cart.total, 8.99);
  });
}
