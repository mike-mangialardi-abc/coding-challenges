# Tracks on-hand quantity per SKU and answers low-stock queries.
#
# IMPLEMENT EVERY METHOD BELOW. Do not change the public signatures.
# The test suite in spec/inventory_tracker_spec.rb defines the exact
# expected behaviour.
#
# Example use (illustrative, not a test):
#
#   inv = InventoryTracker.new
#   inv.receive("WIDGET", 10)
#   inv.ship("WIDGET", 3)
#   # inv.stock("WIDGET")       => 7
#   # inv.low_stock_skus(8)     => ["WIDGET"]
#
# For invalid ship operations (unknown SKU, or shipping more than is in stock),
# raise ArgumentError.
class InventoryTracker
  def initialize
    raise NotImplementedError
  end

  def receive(sku, quantity)
    raise NotImplementedError
  end

  def ship(sku, quantity)
    raise NotImplementedError
  end

  def stock(sku)
    raise NotImplementedError
  end

  def low_stock_skus(threshold)
    raise NotImplementedError
  end
end
