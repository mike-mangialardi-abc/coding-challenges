/// A per-client fixed-window rate limiter.
///
/// IMPLEMENT EVERY MEMBER BELOW. Do not change the public signatures.
/// The test suite in test/rate_limiter_test.dart defines the exact expected
/// behaviour.
///
/// Example use (illustrative, not a test):
///
///     final limiter = RateLimiter(3, 10);
///     limiter.allow('alice', 100); // true   (1st in window)
///     limiter.allow('alice', 101); // true
///     limiter.allow('alice', 102); // true
///     limiter.allow('alice', 103); // false  (over the limit)
///     limiter.allow('alice', 110); // true   (new window)
///
/// `allow` always returns a bool. There are no error cases.
class RateLimiter {
  RateLimiter(int maxRequests, int windowSeconds) {
    throw UnimplementedError();
  }

  bool allow(String clientId, int nowEpochSeconds) {
    throw UnimplementedError();
  }
}
