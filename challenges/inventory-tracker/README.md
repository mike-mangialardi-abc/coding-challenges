# Inventory Tracker

Implement a small inventory tracker that maintains the on-hand quantity for each SKU and answers low-stock queries.

This README is the **specification**. The tests are the **acceptance criteria**. Your job is to make all tests pass.

## What you'll build

A class called **`InventoryTracker`** with these capabilities:

- **Receive stock** for a SKU: `receive(sku, quantity)`. If the SKU has never been seen, it becomes tracked at that quantity. If it already exists, the quantity is added to the existing stock.
- **Ship stock** for a SKU: `ship(sku, quantity)`. Reduces the on-hand quantity. **Must reject** the operation if:
  - the SKU has never been received, or
  - shipping the requested quantity would take stock below `0`.

  When rejected, the existing stock for that SKU must be **unchanged**.
- **Stock** for a SKU: `stock(sku)` returns the current on-hand quantity. Returns `0` for a SKU that has never been received.
- **Low-stock SKUs**: `lowStockSkus(threshold)` returns the SKUs whose current stock is **strictly less than** `threshold`, sorted alphabetically (ascending).

## Behaviour rules

- A SKU is a non-empty string. Quantities and thresholds are non-negative integers. You do not need to defensively validate types or signs — the tests will not exercise invalid inputs.
- A SKU that's been shipped down to `0` is still tracked. It will show up in `lowStockSkus(threshold)` as long as `0 < threshold`.
- A SKU that has never been received does **not** appear in `lowStockSkus`, even if `threshold > 0`. Only tracked SKUs are considered.
- "Strictly less than" means `stock == threshold` is **excluded** and `stock == threshold - 1` is **included**.

## How errors are reported

When `ship` is rejected (unknown SKU, or would go negative), report it in the **idiomatic way for the language** — the stub class's documentation comment in your project tells you the exact mechanism (exception type, return value, etc.). The tests will tell you what they expect.

## What you should NOT do

- Don't add features that aren't tested (reservations, multi-warehouse, history, persistence, etc.).
- Don't change the test files.
- Don't change the public method signatures of `InventoryTracker`.

## How to run the tests

See the `README.md` inside your language's project folder for the exact commands. **Run the tests before you write any code** — they should start failing. Use the failures as your guide.

## Suggested order of attack

1. Read this file.
2. Open the stub class — it lists the methods you need to implement.
3. Run the tests and read the first failure.
4. Implement just enough to make that test pass.
5. Repeat.
