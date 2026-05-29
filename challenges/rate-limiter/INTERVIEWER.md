# Rate Limiter — Interviewer Notes

> **Do not share this file with the candidate.**

## At a glance

- **Tests:** 10 per language, ordered easy → tricky.
- **Target time:** 20–25 minutes for a solid entry-level candidate.
- **Skills exercised:** per-key state in a map, simple window math (subtraction + comparison), conditional logic.

## Canonical test list (language-agnostic)

All tests use `new RateLimiter(maxRequests=3, windowSeconds=10)` unless otherwise noted.

1. First request from any client returns `true`.
2. Three requests for the same client at `t = 100, 101, 102` all return `true`.
3. A fourth request at `t = 103` returns `false`.
4. A fifth request at `t = 103` still returns `false` (denials don't suddenly allow).
5. After exhausting the limit at `t = 100..102`, a request at `t = 110` returns `true` — the window has elapsed.
6. After the window resets at `t = 110`, three requests at `t = 110, 111, 112` are all allowed.
7. Boundary: after the first call at `t = 100`, with max=3, the third call at `t = 102` is allowed; a fourth call at `t = 109` (1 second before boundary) is denied; a call at `t = 110` (exactly `windowStart + windowSeconds`) is allowed (new window).
8. Two different clients are independent: client `A` exhausts the limit at `t = 100..102`; a request from client `B` at `t = 102` returns `true`.
9. Different clients keep independent windows: `A`'s window starts at `t = 100`, `B`'s window starts at `t = 200` — at `t = 205` `A` is in their second window and `B` is still in their first.
10. With a different config `new RateLimiter(max=1, window=5)`: first call at `t = 100` true, second at `t = 100` false, call at `t = 104` false, call at `t = 105` true.

## Reference solution sketch

- Store a dictionary `clientId -> (windowStart: int, count: int)`.
- On `allow(clientId, now)`:
  - If no entry for `clientId` or `now - windowStart >= windowSeconds`: start a new window — set `windowStart = now`, `count = 1`, return `true`.
  - Else if `count < maxRequests`: increment `count`, return `true`.
  - Else return `false` **without touching state**.

## Hint ladder

**If they haven't started:**
1. "Run the tests first. What's the first failure say?"

**If stuck on data structure:**
1. "How are you tracking each client's state?"
2. "What does each client need to remember? When their window started, and how many requests they've made."
3. (Structural) "Dictionary keyed by client id; value is a small struct/tuple/pair of `windowStart` and `count`."

**If stuck on the new-window logic:**
1. "What's the very first thing to check on each request?"
2. "If the client is brand new, or their previous window has expired, what happens?"
3. (Structural) "If unknown client OR `now - windowStart >= windowSeconds`, start a new window: store `(now, 1)` and return `true`."

**If stuck on the boundary (test 7):**
1. "Read test 7 carefully. At which exact time does the new window begin?"
2. "What comparison gives you 'now is `>= windowSeconds` after the window start'?"
3. (Structural) "Use `now - windowStart >= windowSeconds`, NOT `>`."

**If stuck on per-client isolation (tests 8–9):**
1. "If A's state and B's state are both in your dictionary, what could make them affect each other?"
2. (Structural) "Look up by `clientId` only — never iterate other clients."

**If stuck on denials being sticky (test 4):**
1. "What does your code do when the count is already at the limit?"
2. "Are you modifying any state on a denial? Should you be?"
3. (Structural) "Return `false` without touching `count` or `windowStart`."

## Probing follow-ups

- "What's the difference between a fixed-window limiter and a sliding-window limiter? Which is fairer?"
- "How would this behave if the system clock skewed backwards?"
- "If a million clients were tracked, what would you do about the memory?"
- "How would you make this safe to call from many threads at once?"

## Stretch task (if they finish with >10 min left)

"Add a method `remainingRequests(clientId, nowEpochSeconds)` that returns the number of requests the client could still make in their current window. If the client's window has expired (or they've never been seen), it returns the full `maxRequests`."

This forces them to reuse the window-expiry check in a second method without duplicating logic — watch whether they extract a helper.

## Common pitfalls

- **`now - windowStart > windowSeconds`** (off-by-one) instead of `>=`. Test 7 catches this.
- **Increments `count` on denials**, sometimes flipping things back to allowed unexpectedly. Test 4 catches this.
- **Resets the window only on allow** (not on first-call-of-new-window) — usually accidentally combined with the previous bug.
- **Shares state across clients** by using a global counter. Test 8 catches this.
- **Uses real wall clock** despite the spec saying the time is passed in. Hint: redirect them to the parameter.

## Solutions per language

To see one quickly, open `challenges/rate-limiter/<language>/` and apply the sketch above. The test file encodes every expected behaviour.
