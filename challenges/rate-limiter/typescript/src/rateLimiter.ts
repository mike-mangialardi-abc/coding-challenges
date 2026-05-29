/**
 * A per-client fixed-window rate limiter.
 *
 * IMPLEMENT EVERY MEMBER BELOW. Do not change the public signatures.
 * The test suite in rateLimiter.test.ts defines the exact expected behaviour.
 *
 * Example use (illustrative, not a test):
 *
 *     const limiter = new RateLimiter(3, 10);
 *     limiter.allow("alice", 100); // true   (1st in window)
 *     limiter.allow("alice", 101); // true
 *     limiter.allow("alice", 102); // true
 *     limiter.allow("alice", 103); // false  (over the limit)
 *     limiter.allow("alice", 110); // true   (new window)
 *
 * `allow` always returns a boolean. There are no error cases.
 */
export class RateLimiter {
  constructor(maxRequests: number, windowSeconds: number) {
    throw new Error("Not implemented");
  }

  allow(clientId: string, nowEpochSeconds: number): boolean {
    throw new Error("Not implemented");
  }
}
