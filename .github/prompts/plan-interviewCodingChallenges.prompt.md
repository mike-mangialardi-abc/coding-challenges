# Plan: Entry-Level Coding Challenge Repository (3 challenges × 6 languages)

## TL;DR
Build a `coding-challenges` repo containing three equal-difficulty, 20–30 min interview problems — **Shopping Cart**, **Inventory Tracker**, **Rate Limiter** — each implemented in C#, TypeScript, Python, Java, Ruby, and Dart. Every language variant is a self-contained, runnable mini-project with a candidate-facing README, a stub class with method signatures + docstrings (no inline hints), and a passing-when-correct test suite. Each challenge also ships an interviewer script (kept out of the candidate-visible folder) with reference solution, hints to offer if stuck, probing questions, and a stretch task.

---

## Scope

**In scope**
- 3 challenges × 6 languages = 18 candidate projects
- 3 interviewer scripts (one per challenge, language-agnostic with per-language solution snippets)
- Top-level README explaining how interviewers pick + deliver a challenge
- Each project runs out-of-the-box with one documented command (e.g., `dotnet test`, `npm test`, `pytest`, `mvn test`, `rspec`, `dart test`)

**Out of scope**
- CI/GitHub Actions
- Docker/devcontainer setup
- Automated grading
- Solutions checked into candidate-visible folders

---

## Repository Layout

```
coding-challenges/
├── README.md                         # Interviewer overview: how to pick & deliver
├── INTERVIEWER_GUIDE.md              # Shared rubric, time pacing, conduct tips
└── challenges/
    ├── shopping-cart/
    │   ├── README.md                 # Candidate-facing problem statement
    │   ├── INTERVIEWER.md            # Solution, hints, probes, stretch (DO NOT SHARE)
    │   ├── csharp/
    │   ├── typescript/
    │   ├── python/
    │   ├── java/
    │   ├── ruby/
    │   └── dart/
    ├── inventory-tracker/
    │   └── ... (same shape)
    └── rate-limiter/
        └── ... (same shape)
```

Per-language project contents (consistent shape):
- Build/manifest file (`*.csproj`, `package.json`+`tsconfig.json`, `pyproject.toml` or `requirements.txt`, `pom.xml`, `Gemfile`, `pubspec.yaml`)
- `src/` or equivalent containing **one stub class** with method signatures + docstring/XML-doc + `TODO` markers — no inline hints
- `tests/` with a suite of unit tests that the candidate runs to verify their solution
- Short language-specific `RUN.md` (or section in README): one command to install deps + one command to run tests

---

## The Three Challenges

All three test reading comprehension, fundamentals (control flow, collections, simple state), and a small amount of edge-case handling. Calibrated so a competent entry-level candidate finishes in 20–30 minutes.

### 1. Shopping Cart
- **Class**: `ShoppingCart` with methods like `AddItem(name, unitPrice, quantity)`, `RemoveItem(name)`, `ApplyDiscountCode(code)`, `GetTotal()`.
- **Discount codes**: map to percentage discounts applied to the cart total (not per-item). Two or three hardcoded valid codes defined in the candidate README, e.g. `SAVE10` → 10% off, `SAVE20` → 20% off, `HALFOFF` → 50% off. Unknown codes are rejected and leave the total unchanged. Only one active discount code at a time; applying a new valid code replaces the previous one.
- **Skills**: collection manipulation, simple arithmetic, lookups, rounding to 2 decimals.
- **Tricky cases tested**: removing nonexistent item, invalid discount code, empty cart total, multiple line items.
- **~8–10 tests** per language.

### 2. Inventory Tracker
- **Class**: `InventoryTracker` with `Receive(sku, qty)`, `Ship(sku, qty)`, `GetStock(sku)`, `LowStockSkus(threshold)`.
- **Threshold semantics**: `LowStockSkus(threshold)` returns SKUs whose current stock is **strictly less than** `threshold` (exclusive). A SKU with stock exactly equal to `threshold` is **not** returned.
- **Skills**: dictionary/map usage, light domain logic, throwing/returning on insufficient stock.
- **Tricky cases tested**: shipping more than on hand, unknown SKU, threshold boundary (stock == threshold excluded; stock == threshold - 1 included), receiving zero/negative qty.
- **~8–10 tests** per language.

### 3. Rate Limiter (fixed-window)
- **Class**: `RateLimiter(maxRequests, windowSeconds)` with `Allow(clientId, timestamp): bool`.
- Caller passes timestamp (seconds since epoch) — keeps it deterministic and avoids time-mocking pain across 6 languages.
- **Skills**: state per key, simple window math (`timestamp / window`), conditional logic.
- **Tricky cases tested**: per-client isolation, exactly-at-limit, rollover into next window, requests in different windows interleaved.
- **~8–10 tests** per language.

---

## Authoring Steps

Steps within a phase can run in parallel. Phases are sequential.

### Phase A — Foundations (sequential)
1. Create top-level `README.md` and `INTERVIEWER_GUIDE.md` (shared rubric: correctness, code clarity, communication, test-running discipline; time pacing notes; how to deliver the challenge; what to share/not share).
2. Lock down candidate-facing `README.md` template (Problem / Class to implement / Method specs / How to run tests / Constraints / What you should NOT do).
3. Lock down `INTERVIEWER.md` template (Reference solution per language / Hints to offer if stuck at N min / Probing follow-ups / Common pitfalls / Stretch task).

### Phase B — Per-challenge specs (parallel: 3 streams)
For each of `shopping-cart`, `inventory-tracker`, `rate-limiter`:
4. Write the candidate `README.md` (problem statement, method signatures in pseudo-form, examples, constraints).
5. Write the `INTERVIEWER.md` (hints, probes, pitfalls, stretch).
6. Define the canonical test cases (language-agnostic list) so all 6 implementations stay in lockstep.

### Phase C — Per-language scaffolding (parallel: 18 streams, grouped by language)
For each (challenge × language) pair:
7. Scaffold the project with the chosen tooling (defaults confirmed):
   - **C#** .NET 8 + xUnit
   - **TypeScript** Node 20 + Vitest
   - **Python** 3.11 + pytest
   - **Java** 17 + JUnit 5 (Maven)
   - **Ruby** 3.x + RSpec
   - **Dart** 3.x + `package:test`
8. Add stub class with idiomatic signatures, docstring/XML-doc explaining contract, `TODO` markers. **No inline hints.**
9. Translate the canonical test cases into idiomatic tests for the language.
10. Verify: tests run, all fail (or fail meaningfully) against the stub; tests all pass against the reference solution.

### Phase D — Interviewer rollup (sequential)
11. Embed per-language reference solution snippets into each challenge's `INTERVIEWER.md`.
12. Final pass: read each candidate README cold to confirm the problem is unambiguous and finishable in 20–30 min.

---

## Annotation & Style Rules

- **Candidate stub class**: method signature + docstring with 1 example + `TODO` marker. No inline hints on tricky bits. Docstring states the contract; surprises (e.g., "throw on unknown SKU") live in the candidate README, not in code comments.
- **Hints live only in `INTERVIEWER.md`**, keyed to where a candidate is likely to get stuck, so the interviewer can prompt them.
- **Tests**: descriptively named, one assertion concept per test, ordered easy→tricky so a partial implementation gets partial passing tests (useful signal for the interviewer).

---

## Relevant files (to be created)

- `README.md` — interviewer-facing repo overview
- `INTERVIEWER_GUIDE.md` — shared rubric, pacing, conduct
- `challenges/<challenge>/README.md` — candidate problem statement (× 3)
- `challenges/<challenge>/INTERVIEWER.md` — solution + hints + probes + stretch (× 3)
- `challenges/<challenge>/<language>/...` — 18 runnable project scaffolds

---

## Verification

1. From a clean clone, follow each candidate `README.md` end-to-end in each language; confirm one command installs deps and one command runs tests.
2. With stub unchanged: every test suite reports failing tests (not compile errors that mask the problem).
3. With reference solution pasted in: every test suite is green in all 6 languages for all 3 challenges (18 green runs).
4. Time-box dry run: a mid-level engineer solves each challenge cold in ≤ 30 min in their primary language. If consistently > 30 min, trim a method or simplify edge cases.
5. Read-aloud check: a non-author reads each candidate `README.md` and can restate the problem + at least 3 edge cases without looking at tests.

---

## Decisions captured

- **Themes**: Shopping Cart, Inventory Tracker, Rate Limiter (fixed window, deterministic timestamp param).
- **Difficulty**: three equal alternatives — interviewer picks one.
- **Layout**: challenge-first (`challenges/<name>/<language>/`).
- **Tooling**: defaults above accepted.
- **Interviewer materials**: reference solution, probing questions, common pitfalls + hints, stretch task. (No time-checkpoint table.)
- **Environment**: local clone, full IDE.
- **Annotation style**: signature + docstring + example + TODO; **no inline hints** — hints live in the interviewer script.

---

## Further considerations

1. **Stretch tasks** — want them spelled out in this plan now, or defined per-challenge during authoring?
2. **Test count per challenge** — 8–10 assumed; bump to 12–15 if you want finer-grained partial-credit signal.
3. **Language parity edge case** — Ruby/Python are dynamically typed; should the stub use type hints / RBS / Sorbet, or stay idiomatic untyped to match how juniors typically write those languages? (Recommend: idiomatic untyped, with types only in C#/TS/Java/Dart.)
