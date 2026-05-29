# Rate Limiter

Implement a simple per-client **fixed-window** rate limiter.

This README is the **specification**. The tests are the **acceptance criteria**. Your job is to make all tests pass.

## What you'll build

A class called **`RateLimiter`** with:

- A **constructor** that takes two integers: `maxRequests` and `windowSeconds`.
- A method **`allow(clientId, nowEpochSeconds)`** that returns `true` if the request is allowed and `false` if the client has exceeded the limit. `clientId` is a string. `nowEpochSeconds` is a non-negative integer (seconds since the Unix epoch — but for the purposes of this exercise, just treat it as "the current time in seconds").

You will **not** call any real clock function — the time is always passed in by the caller. That keeps the tests deterministic.

## Behaviour rules

- Each client gets their own independent window.
- A client's window starts at the time of **that client's first request** (or the first request after their previous window has expired). It lasts exactly `windowSeconds` seconds.
- While a client's current window is open, **up to `maxRequests` requests** are allowed. Any further requests in the same window are denied.
- Once `windowSeconds` have elapsed since the start of the current window (i.e. `now - windowStart >= windowSeconds`), a **new window** begins on the next request. The count is reset and that request is allowed.
- **Denied requests do not consume capacity** — a denial doesn't extend the window or change anything; the next request in the same window will be denied for the same reason.
- The boundary is **strict**: at `t = windowStart + windowSeconds` you are in a new window. At `t = windowStart + windowSeconds - 1` you are still in the old window.
- Tests will only ever pass monotonically non-decreasing `nowEpochSeconds` (time never moves backwards).
- Two different clients are **completely independent**: client A hitting their limit has no effect on client B.

## How errors are reported

This challenge has no error cases. `allow` always returns a boolean. You do not need to throw, raise, or return anything else.

## What you should NOT do

- Don't call the system clock. Always use the `nowEpochSeconds` argument.
- Don't add unrequested features (logging, per-client config, rolling windows, etc.).
- Don't change the test files.
- Don't change the public method signatures of `RateLimiter`.

## How to run the tests

See the `README.md` inside your language's project folder for the exact commands. **Run the tests before you write any code** — they should start failing. Use the failures as your guide.

## Suggested order of attack

1. Read this file.
2. Open the stub class — it lists the methods you need to implement.
3. Run the tests and read the first failure.
4. Implement just enough to make that test pass.
5. Repeat.
