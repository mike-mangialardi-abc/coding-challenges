# Inventory Tracker — Interviewer Notes

> **Do not share this file with the candidate.**

## At a glance

- **Tests:** 10 per language, ordered easy → tricky.
- **Target time:** 20–25 minutes for a solid entry-level candidate.
- **Skills exercised:** dictionary/map usage, error handling, boundary conditions, simple list filtering & sorting.

## Canonical test list (language-agnostic)

1. New tracker: `stock("A")` is `0`; `lowStockSkus(100)` is empty.
2. Receive a new SKU: `receive("A", 5)` → `stock("A") == 5`.
3. Multiple receives accumulate: `receive("A", 5)` then `receive("A", 3)` → `stock("A") == 8`.
4. Ship reduces stock: after `receive("A", 5)`, `ship("A", 2)` → `stock("A") == 3`.
5. Ship down to exactly zero is allowed: after `receive("A", 5)`, `ship("A", 5)` → `stock("A") == 0`, **no error**.
6. Ship more than available is rejected and stock is unchanged: `ship("A", 10)` on `stock == 5` raises and `stock("A")` is still `5`.
7. Ship on a SKU that was never received is rejected.
8. `lowStockSkus(threshold)` excludes SKUs at the threshold and includes SKUs below it. Set up SKUs with stock `0`, `4`, `5`, `6`; call `lowStockSkus(5)` → returns `["A", "B"]` (the 0 and the 4), not the 5 or the 6.
9. `lowStockSkus(threshold)` returns SKUs in alphabetical order.
10. SKUs that have never been received are not reported in `lowStockSkus`, even with `threshold == 100`.

## Reference solution sketch

- Store stock in a dictionary `sku -> int`.
- `receive`: `stock[sku] = stock.get(sku, 0) + quantity`.
- `ship`: validate `sku in stock` and `stock[sku] >= quantity`; raise otherwise; subtract.
- `stock(sku)`: `dict.get(sku, 0)`.
- `lowStockSkus(threshold)`: `sorted(s for s, q in stock.items() if q < threshold)`.

## Hint ladder

**If they haven't started:**
1. "Run the tests first. What's the first failure say?"

**If stuck on data structure:**
1. "How would you track the quantity for each SKU? What's good for looking up by name?"
2. (Structural) "A dictionary keyed by SKU."

**If stuck on `receive` accumulating:**
1. "What does test 3 expect when you receive the same SKU twice?"
2. "How do you read the current value before writing the new one? What if there isn't one yet?"
3. (Structural) "Use `dict.get(sku, 0) + qty`, or check `if sku in dict`."

**If stuck on `ship` validation:**
1. "What two ways can shipping fail? Read tests 6 and 7."
2. "Check both conditions before subtracting — what should you do if either fails?"
3. (Structural) "If unknown SKU or quantity > stock, raise; else subtract."

**If stuck on `stock` for unknown SKU:**
1. "What does test 1 expect when you ask for the stock of `'A'` with no setup?"
2. (Structural) "Return `0` for unknown SKUs — don't raise."

**If stuck on `lowStockSkus` boundary:**
1. "Re-read test 8 carefully. Which SKUs are in the expected list and which aren't?"
2. "What's the comparison — `<`, `<=`, or `==`?"
3. (Structural) "Strictly less than (`<`)."

**If stuck on sort:**
1. "Test 9 expects a specific order. What is it?"
2. (Structural) "Sort the result alphabetically — use your language's built-in `sort` / `sorted`."

## Probing follow-ups

- "Suppose stock changes thousands of times per second. Anything in your design that gets slow?"
- "How would you extend this to track stock per warehouse?"
- "What would you test that we don't?"
- "If ship requests could come from many threads simultaneously, what could go wrong?"

## Stretch task (if they finish with >10 min left)

"Add a `reorderPoint(sku, point)` method that stores a per-SKU low-stock threshold. Then add `skusBelowReorderPoint()` which returns every SKU whose current stock is strictly below **its own** reorder point. SKUs without a reorder point are never reported."

This tests their ability to extend the data model cleanly.

## Common pitfalls

- **Uses `<=` instead of `<`** in `lowStockSkus`. Test 8 catches this.
- **Mutates stock before validating** in `ship` — partial subtraction then raises. Test 6 catches this (stock must be unchanged after rejection).
- **Returns unsorted result** from `lowStockSkus`. Test 9 catches this.
- **Includes never-received SKUs** somehow (e.g. always returning a hardcoded list). Test 10 catches this.
- **Raises in `stock(sku)` for unknown SKU** instead of returning `0`. Test 1 catches this.

## Solutions per language

To see one quickly, open `challenges/inventory-tracker/<language>/` and apply the sketch above. The test file encodes every expected behaviour.
