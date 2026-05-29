# Shopping Cart

Implement a small shopping cart that totals line items and applies a single discount code.

This README is the **specification**. The tests are the **acceptance criteria**. Your job is to make all tests pass.

## What you'll build

A class called **`ShoppingCart`** with these capabilities:

- **Add an item** with a name, a unit price, and a quantity.
- **Remove an item** by name. Removing an item that isn't in the cart is allowed (it's a no-op).
- **Apply a discount code** that reduces the total by a percentage. Only one code can be active at a time; applying a new valid code replaces the previous one. Applying an unknown code must be rejected (see "How errors are reported" below).
- **Clear the active discount code.**
- **Total** — the current total price after the active discount, if any, rounded to **2 decimal places**.
- **Item count** — the number of distinct items in the cart (not the sum of quantities).

## Discount codes

There are exactly three valid codes (case-sensitive):

| Code | Effect |
| --- | --- |
| `SAVE10` | 10% off the total |
| `SAVE20` | 20% off the total |
| `HALFOFF` | 50% off the total |

- The discount applies to the **total of all line items**, not to individual items.
- Any other code (including empty string, lowercase variants, or `null`/`None`) is **unknown** and must be rejected.

## Behaviour rules

- Adding the same item name twice should **increase the quantity**, not create a duplicate line.
- Quantities and unit prices are always non-negative. You do not need to defensively check for negative values — the tests will not pass them.
- An empty cart has a total of `0.00` and an item count of `0`.
- Removing the last item leaves the cart with total `0.00`. A previously-applied discount code stays active but has nothing to apply to.

## How errors are reported

When the candidate-facing code needs to "reject" something (only the unknown-discount-code case in this challenge), it should do so in the **idiomatic way for the language** — see the stub class's documentation comment in your project for the exact mechanism (exception type, return value, etc.). The tests will tell you what they expect.

## What you should NOT do

- Don't add features that aren't tested (tax, shipping, currency conversion, persistence, logging, etc.).
- Don't change the test files.
- Don't change the public method signatures of `ShoppingCart`.
- Don't worry about thread safety, I/O, or networking.

## How to run the tests

See the `README.md` inside your language's project folder for the exact commands. In general: install dependencies once, then run the test command. **Run the tests before you write any code** — they should start failing. Use the failures as your guide.

## Suggested order of attack

1. Read this file.
2. Open the stub class — it lists the methods you need to implement.
3. Run the tests and read the first failure.
4. Implement just enough to make that test pass.
5. Repeat.
