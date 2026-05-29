import 'package:test/test.dart';
import 'package:inventory_tracker_challenge/inventory_tracker.dart';

void main() {
  test('new tracker is empty', () {
    final inv = InventoryTracker();
    expect(inv.stock('A'), 0);
    expect(inv.lowStockSkus(100), <String>[]);
  });

  test('receive creates a SKU with the given quantity', () {
    final inv = InventoryTracker();
    inv.receive('A', 5);

    expect(inv.stock('A'), 5);
  });

  test('repeated receives accumulate', () {
    final inv = InventoryTracker();
    inv.receive('A', 5);
    inv.receive('A', 3);

    expect(inv.stock('A'), 8);
  });

  test('ship reduces stock', () {
    final inv = InventoryTracker();
    inv.receive('A', 5);
    inv.ship('A', 2);

    expect(inv.stock('A'), 3);
  });

  test('shipping down to exactly zero is allowed', () {
    final inv = InventoryTracker();
    inv.receive('A', 5);

    expect(() => inv.ship('A', 5), returnsNormally);
    expect(inv.stock('A'), 0);
  });

  test('shipping more than available throws and leaves stock unchanged', () {
    final inv = InventoryTracker();
    inv.receive('A', 5);

    expect(() => inv.ship('A', 10), throwsStateError);
    expect(inv.stock('A'), 5);
  });

  test('shipping an unknown SKU throws', () {
    final inv = InventoryTracker();
    expect(() => inv.ship('GHOST', 1), throwsStateError);
  });

  test('lowStockSkus uses a strictly-less-than boundary', () {
    final inv = InventoryTracker();
    inv.receive('A', 5); inv.ship('A', 5); // stock 0
    inv.receive('B', 4);                   // stock 4
    inv.receive('C', 5);                   // stock 5 (at threshold)
    inv.receive('D', 6);                   // stock 6

    expect(inv.lowStockSkus(5), ['A', 'B']);
  });

  test('lowStockSkus returns alphabetical order', () {
    final inv = InventoryTracker();
    inv.receive('Zeta', 1);
    inv.receive('Alpha', 1);
    inv.receive('Mu', 1);

    expect(inv.lowStockSkus(10), ['Alpha', 'Mu', 'Zeta']);
  });

  test('never-received SKUs are not reported', () {
    final inv = InventoryTracker();
    expect(inv.lowStockSkus(100), <String>[]);
  });
}
