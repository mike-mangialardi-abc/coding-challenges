package com.example.ratelimiter;

/**
 * A per-client fixed-window rate limiter.
 *
 * IMPLEMENT EVERY METHOD BELOW. Do not change the public signatures.
 * The test suite in RateLimiterTest.java defines the exact expected behaviour.
 *
 * Example use (illustrative, not a test):
 *
 *     RateLimiter limiter = new RateLimiter(3, 10);
 *     limiter.allow("alice", 100); // true   (1st in window)
 *     limiter.allow("alice", 101); // true
 *     limiter.allow("alice", 102); // true
 *     limiter.allow("alice", 103); // false  (over the limit)
 *     limiter.allow("alice", 110); // true   (new window)
 *
 * `allow` always returns a boolean. There are no error cases.
 */
public class RateLimiter {

    public RateLimiter(int maxRequests, int windowSeconds) {
        throw new UnsupportedOperationException("Not implemented");
    }

    public boolean allow(String clientId, long nowEpochSeconds) {
        throw new UnsupportedOperationException("Not implemented");
    }
}
