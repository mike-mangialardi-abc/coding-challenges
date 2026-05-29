/// Tracks on-hand quantity per SKU and answers low-stock queries.
///
/// IMPLEMENT EVERY MEMBER BELOW. Do not change the public signatures.
/// The test suite in test/inventory_tracker_test.dart defines the exact
/// expected behaviour.
///
/// Example use (illustrative, not a test):
///
///     final inv = InventoryTracker();
///     inv.receive('WIDGET', 10);
///     inv.ship('WIDGET', 3);
///     // inv.stock('WIDGET') == 7
///     // inv.lowStockSkus(8) contains 'WIDGET'
///
/// For invalid ship operations (unknown SKU, or shipping more than is in stock),
/// throw StateError.
class InventoryTracker {
  void receive(String sku, int quantity) {
    throw UnimplementedError();
  }

  void ship(String sku, int quantity) {
    throw UnimplementedError();
  }

  int stock(String sku) {
    throw UnimplementedError();
  }

  List<String> lowStockSkus(int threshold) {
    throw UnimplementedError();
  }
}
