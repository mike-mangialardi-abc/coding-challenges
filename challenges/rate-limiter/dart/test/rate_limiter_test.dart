import 'package:rate_limiter_challenge/rate_limiter.dart';
import 'package:test/test.dart';

void main() {
  test('first request is allowed', () {
    final limiter = RateLimiter(3, 10);
    expect(limiter.allow('alice', 100), isTrue);
  });

  test('requests up to the max are allowed', () {
    final limiter = RateLimiter(3, 10);
    expect(limiter.allow('alice', 100), isTrue);
    expect(limiter.allow('alice', 101), isTrue);
    expect(limiter.allow('alice', 102), isTrue);
  });

  test('request over the limit is denied', () {
    final limiter = RateLimiter(3, 10);
    limiter.allow('alice', 100);
    limiter.allow('alice', 101);
    limiter.allow('alice', 102);

    expect(limiter.allow('alice', 103), isFalse);
  });

  test('denials stay sticky inside the same window', () {
    final limiter = RateLimiter(3, 10);
    limiter.allow('alice', 100);
    limiter.allow('alice', 101);
    limiter.allow('alice', 102);

    expect(limiter.allow('alice', 103), isFalse);
    expect(limiter.allow('alice', 103), isFalse);
  });

  test('after the window elapses, a request is allowed', () {
    final limiter = RateLimiter(3, 10);
    limiter.allow('alice', 100);
    limiter.allow('alice', 101);
    limiter.allow('alice', 102);

    expect(limiter.allow('alice', 110), isTrue);
  });

  test('a new window resets the count', () {
    final limiter = RateLimiter(3, 10);
    limiter.allow('alice', 100);
    limiter.allow('alice', 101);
    limiter.allow('alice', 102);

    expect(limiter.allow('alice', 110), isTrue);
    expect(limiter.allow('alice', 111), isTrue);
    expect(limiter.allow('alice', 112), isTrue);
    expect(limiter.allow('alice', 113), isFalse);
  });

  test('boundary is strict (>= windowSeconds opens a new window)', () {
    final limiter = RateLimiter(3, 10);
    limiter.allow('alice', 100);
    limiter.allow('alice', 101);
    limiter.allow('alice', 102);

    expect(limiter.allow('alice', 109), isFalse);
    expect(limiter.allow('alice', 110), isTrue);
  });

  test('two clients are independent', () {
    final limiter = RateLimiter(3, 10);
    limiter.allow('alice', 100);
    limiter.allow('alice', 101);
    limiter.allow('alice', 102);

    expect(limiter.allow('bob', 102), isTrue);
  });

  test('two clients have independent windows', () {
    final limiter = RateLimiter(3, 10);
    limiter.allow('alice', 100);
    limiter.allow('bob', 200);

    expect(limiter.allow('alice', 205), isTrue);
    expect(limiter.allow('bob', 205), isTrue);
  });

  test('a different config works correctly', () {
    final limiter = RateLimiter(1, 5);
    expect(limiter.allow('x', 100), isTrue);
    expect(limiter.allow('x', 100), isFalse);
    expect(limiter.allow('x', 104), isFalse);
    expect(limiter.allow('x', 105), isTrue);
  });
}
