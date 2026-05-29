namespace RateLimiterChallenge;

/// <summary>
/// A per-client fixed-window rate limiter.
///
/// IMPLEMENT EVERY MEMBER BELOW. Do not change the public signatures.
/// The test suite in RateLimiterTests.cs defines the exact expected behaviour.
///
/// Example use (illustrative, not a test):
///
///     var limiter = new RateLimiter(maxRequests: 3, windowSeconds: 10);
///     limiter.Allow("alice", 100); // true   (1st in window)
///     limiter.Allow("alice", 101); // true   (2nd)
///     limiter.Allow("alice", 102); // true   (3rd)
///     limiter.Allow("alice", 103); // false  (over the limit, still in window)
///     limiter.Allow("alice", 110); // true   (new window starts)
///
/// Allow always returns a bool. There are no error cases.
/// </summary>
public class RateLimiter
{
    public RateLimiter(int maxRequests, int windowSeconds)
    {
        throw new NotImplementedException();
    }

    public bool Allow(string clientId, long nowEpochSeconds)
    {
        throw new NotImplementedException();
    }
}
