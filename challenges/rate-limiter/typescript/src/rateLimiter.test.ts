import { describe, expect, it } from "vitest";
import { RateLimiter } from "./rateLimiter.js";

describe("RateLimiter", () => {
  it("first request is allowed", () => {
    const limiter = new RateLimiter(3, 10);
    expect(limiter.allow("alice", 100)).toBe(true);
  });

  it("requests up to max are allowed", () => {
    const limiter = new RateLimiter(3, 10);
    expect(limiter.allow("alice", 100)).toBe(true);
    expect(limiter.allow("alice", 101)).toBe(true);
    expect(limiter.allow("alice", 102)).toBe(true);
  });

  it("request over the limit is denied", () => {
    const limiter = new RateLimiter(3, 10);
    limiter.allow("alice", 100);
    limiter.allow("alice", 101);
    limiter.allow("alice", 102);

    expect(limiter.allow("alice", 103)).toBe(false);
  });

  it("denials stay sticky inside the same window", () => {
    const limiter = new RateLimiter(3, 10);
    limiter.allow("alice", 100);
    limiter.allow("alice", 101);
    limiter.allow("alice", 102);

    expect(limiter.allow("alice", 103)).toBe(false);
    expect(limiter.allow("alice", 103)).toBe(false);
  });

  it("after the window elapses, a request is allowed", () => {
    const limiter = new RateLimiter(3, 10);
    limiter.allow("alice", 100);
    limiter.allow("alice", 101);
    limiter.allow("alice", 102);

    expect(limiter.allow("alice", 110)).toBe(true);
  });

  it("a new window resets the count", () => {
    const limiter = new RateLimiter(3, 10);
    limiter.allow("alice", 100);
    limiter.allow("alice", 101);
    limiter.allow("alice", 102);

    expect(limiter.allow("alice", 110)).toBe(true);
    expect(limiter.allow("alice", 111)).toBe(true);
    expect(limiter.allow("alice", 112)).toBe(true);
    expect(limiter.allow("alice", 113)).toBe(false);
  });

  it("boundary is strict (>= windowSeconds opens a new window)", () => {
    const limiter = new RateLimiter(3, 10);
    limiter.allow("alice", 100);
    limiter.allow("alice", 101);
    limiter.allow("alice", 102);

    expect(limiter.allow("alice", 109)).toBe(false);
    expect(limiter.allow("alice", 110)).toBe(true);
  });

  it("two clients are independent", () => {
    const limiter = new RateLimiter(3, 10);
    limiter.allow("alice", 100);
    limiter.allow("alice", 101);
    limiter.allow("alice", 102);

    expect(limiter.allow("bob", 102)).toBe(true);
  });

  it("two clients have independent windows", () => {
    const limiter = new RateLimiter(3, 10);
    limiter.allow("alice", 100);
    limiter.allow("bob", 200);

    expect(limiter.allow("alice", 205)).toBe(true);
    expect(limiter.allow("bob", 205)).toBe(true);
  });

  it("a different config works correctly", () => {
    const limiter = new RateLimiter(1, 5);
    expect(limiter.allow("x", 100)).toBe(true);
    expect(limiter.allow("x", 100)).toBe(false);
    expect(limiter.allow("x", 104)).toBe(false);
    expect(limiter.allow("x", 105)).toBe(true);
  });
});
