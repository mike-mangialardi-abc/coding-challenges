# Coding Challenges — Entry-Level Engineer Interview

Three interchangeable take-home-style coding problems for evaluating entry-level software engineering candidates during a live technical interview.

Each challenge is:

- Sized for **20–30 minutes** of focused work
- Available in **six languages**: C#, TypeScript, Python, Java, Ruby, Dart
- A small, heavily-documented project: one stub class to implement, one suite of unit tests to verify the implementation
- Backed by an interviewer-only script (`INTERVIEWER.md`) with the reference solution, hints to offer if the candidate gets stuck, follow-up questions, and a stretch task

## The three challenges

| Folder | Problem | What it primarily tests |
| --- | --- | --- |
| [challenges/shopping-cart](challenges/shopping-cart) | Build a shopping cart that totals line items and applies discount codes. | Collections, simple arithmetic, lookups, rounding. |
| [challenges/inventory-tracker](challenges/inventory-tracker) | Track stock per SKU; support receiving, shipping, and low-stock queries. | Map/dictionary usage, error handling, boundary conditions. |
| [challenges/rate-limiter](challenges/rate-limiter) | Implement a fixed-window per-client rate limiter. | Per-key state, simple window math, conditional logic. |

The three challenges are calibrated to be **roughly equal difficulty** — interviewers pick whichever one they prefer (or rotate to avoid leakage).

## How to run an interview with this repo

1. Read [INTERVIEWER_GUIDE.md](INTERVIEWER_GUIDE.md) end-to-end **before** your first interview.
2. Pick one challenge (`shopping-cart`, `inventory-tracker`, or `rate-limiter`).
3. Pick the language the candidate is most comfortable in.
4. Send the candidate **only** the `challenges/<challenge>/<language>/` folder plus the challenge's `README.md`. **Do not** send `INTERVIEWER.md` — it contains the answer.
5. Have the candidate clone, install dependencies, run the tests (they should start red), and fill in the stub class until the tests go green.

## Repository layout

```
coding-challenges/
├── README.md                         # This file
├── INTERVIEWER_GUIDE.md              # Shared rubric, pacing, conduct tips
└── challenges/
    ├── shopping-cart/
    │   ├── README.md                 # Candidate-facing problem statement
    │   ├── INTERVIEWER.md            # Solution + hints + probes (DO NOT SHARE)
    │   ├── csharp/   typescript/   python/   java/   ruby/   dart/
    ├── inventory-tracker/    (same shape)
    └── rate-limiter/         (same shape)
```

## Required toolchains (per language)

The candidate only needs the toolchain for the language they're using.

| Language | Runtime | Test runner | Run tests |
| --- | --- | --- | --- |
| C# | .NET 8 SDK | xUnit | `dotnet test` |
| TypeScript | Node 20+ | Vitest | `npm install && npm test` |
| Python | Python 3.11+ | pytest | `pip install -r requirements.txt && pytest` |
| Java | JDK 17+ & Maven 3.9+ | JUnit 5 | `mvn test` |
| Ruby | Ruby 3.x & Bundler | RSpec | `bundle install && bundle exec rspec` |
| Dart | Dart SDK 3.x | `package:test` | `dart pub get && dart test` |
