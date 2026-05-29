# Shopping Cart — Interviewer Notes

> **Do not share this file with the candidate.**

## At a glance

- **Tests:** 10 per language, ordered easy → tricky.
- **Target time:** 20–25 minutes for a solid entry-level candidate.
- **Skills exercised:** dictionary/map usage, simple arithmetic, lookups, decimal rounding.

## Canonical test list (language-agnostic)

The same 10 cases exist in every language's test file. They are ordered to give the candidate progressive feedback.

1. New cart: total is `0.00`, item count is `0`.
2. Add one item (`Apple`, `1.50`, qty `2`): item count `1`, total `3.00`.
3. Add two different items: item count `2`, total sums correctly.
4. Adding the same item name twice increases the quantity (item count stays `1`, total reflects combined qty).
5. Remove an item by name reduces total and item count.
6. Removing an item that isn't in the cart is a no-op (no exception, totals unchanged).
7. Apply `SAVE10` to a `100.00` cart → total `90.00`.
8. Apply `HALFOFF` to a `10.00` cart → total `5.00`. Applying `SAVE20` afterward replaces it → total `8.00`.
9. Applying an unknown code (`"BOGUS"`) is rejected in the language-idiomatic way (exception in C#/Java/TS/Python/Dart; raise in Ruby). The previously-active code is **unchanged** if any.
10. Rounding: a discount that produces a fractional cent (e.g. `9.99` with `SAVE10` → `8.991`) rounds to 2dp (`8.99`).

## Reference solution sketch

The expected implementation is intentionally boring:

- Store items in a dictionary keyed by name → `(unitPrice, quantity)`.
- `AddItem(name, price, qty)`: if the key exists, increment quantity; otherwise insert. (Decision: should the unit price be updated on re-add? **Yes — use the most recently provided unit price.** This is tested implicitly in case 4 — pass the same price both times so the question doesn't arise. If the candidate asks, tell them "use the most recent price" and move on.)
- `RemoveItem(name)`: dictionary delete; ignore missing key.
- Discount: store a single optional code string. On `ApplyDiscountCode`, validate against the fixed table `{SAVE10: 0.10, SAVE20: 0.20, HALFOFF: 0.50}` — if not present, throw/raise.
- `Total`: sum `price * qty` across items; if a discount code is active, multiply by `(1 - rate)`; round to 2dp half-away-from-zero.
- `ItemCount`: `dict.size`.

## Hint ladder

Walk down step-by-step. Don't skip rungs.

**If they haven't started:**
1. "Have you run the tests yet? What's the first failure say?"
2. "Open the stub class — what methods are listed?"

**If stuck on data structure:**
1. "How are you tracking the items? What would be easy to look up by name?"
2. "Could a dictionary / map / hash help here?"
3. (Structural) "Use a dictionary keyed by item name — the value is the price and quantity."

**If stuck on `AddItem` with same name twice:**
1. "What does test case 4 expect to happen if you add `Apple` twice?"
2. "How would you detect that the item already exists before adding?"
3. (Structural) "Check `if name in items: items[name].quantity += qty` else insert."

**If stuck on discount codes:**
1. "How many valid codes are there? Where in the README does it list them?"
2. "What's the simplest way to map a code to its percentage?"
3. (Structural) "A small lookup table — dictionary or switch — from code string to percentage."

**If stuck on unknown-code rejection:**
1. "What does test case 9 do when you pass `BOGUS`? Read the test."
2. "What does the language usually do to signal 'invalid argument'?"
3. (Structural) "Throw `ArgumentException` / raise `ValueError` / `throw new Error` / `raise ArgumentError` / `throw ArgumentError()`."

**If stuck on rounding:**
1. "Try running test 10. What's the actual vs expected?"
2. "How would you turn a number like `8.991` into `8.99`?"
3. (Structural) Language-specific: C# `Math.Round(x, 2)`; Python `round(x, 2)` (or `Decimal` quantize); TS/JS `Math.round(x * 100) / 100`; Java `BigDecimal.setScale(2, RoundingMode.HALF_UP)`; Ruby `x.round(2)`; Dart `double.parse(x.toStringAsFixed(2))`.

## Probing follow-ups (5–10 min after coding)

Pick one or two:

- "Suppose discount codes weren't hardcoded — how would you let an admin add new ones?"
- "What would change if we needed per-line-item discounts instead of order-level?"
- "What new tests would you write to be confident this is correct?"
- "What happens if the cart has 100,000 items? Does anything in your implementation get slow?"

## Stretch task (if they finish with >10 min left)

"Add a `BOGO` (buy-one-get-one) discount code: for any item with quantity ≥ 2, every second unit is free. This stacks **instead of** the percentage codes, not on top of them."

This forces them to redesign the discount mechanism from a single percentage into a strategy. Watch how they refactor.

## Common pitfalls

- **Mutates the iteration target** (e.g. modifies dict while iterating in Total). Should not happen here but watch.
- **Stores discount as a percentage value instead of a code**, then forgets to validate on apply. The validation has to happen at `ApplyDiscountCode` time, not at `Total` time.
- **Treats item count as sum of quantities** instead of number of distinct items. Test 4 catches this.
- **Forgets rounding** until test 10 fails. Encourage them to centralise the rounding in `Total`.
- **Lowercases the code** "to be helpful". The spec says case-sensitive — explicitly mention this if asked.

## Solutions per language

The full reference solutions live alongside each language's stub. To see one quickly: open `challenges/shopping-cart/<language>/` and mentally apply the sketch above — or peek at the test file, which encodes every expected behaviour.
