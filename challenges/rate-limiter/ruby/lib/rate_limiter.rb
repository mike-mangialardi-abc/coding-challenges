# A per-client fixed-window rate limiter.
#
# IMPLEMENT EVERY METHOD BELOW. Do not change the public signatures.
# The test suite in spec/rate_limiter_spec.rb defines the exact expected behaviour.
#
# Example use (illustrative, not a test):
#
#     limiter = RateLimiter.new(3, 10)
#     limiter.allow("alice", 100)   # true   (1st in window)
#     limiter.allow("alice", 101)   # true
#     limiter.allow("alice", 102)   # true
#     limiter.allow("alice", 103)   # false  (over the limit)
#     limiter.allow("alice", 110)   # true   (new window)
#
# `allow` always returns true or false. There are no error cases.
class RateLimiter
  def initialize(max_requests, window_seconds)
    raise NotImplementedError
  end

  def allow(client_id, now_epoch_seconds)
    raise NotImplementedError
  end
end
