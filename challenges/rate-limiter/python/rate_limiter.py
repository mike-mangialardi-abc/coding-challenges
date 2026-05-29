"""A per-client fixed-window rate limiter.

IMPLEMENT EVERY METHOD BELOW. Do not change the public signatures.
The test suite in test_rate_limiter.py defines the exact expected behaviour.

Example use (illustrative, not a test):

    limiter = RateLimiter(max_requests=3, window_seconds=10)
    limiter.allow("alice", 100)   # True   (1st in window)
    limiter.allow("alice", 101)   # True
    limiter.allow("alice", 102)   # True
    limiter.allow("alice", 103)   # False  (over the limit)
    limiter.allow("alice", 110)   # True   (new window)

`allow` always returns a bool. There are no error cases.
"""


class RateLimiter:
    def __init__(self, max_requests, window_seconds):
        raise NotImplementedError

    def allow(self, client_id, now_epoch_seconds):
        raise NotImplementedError
