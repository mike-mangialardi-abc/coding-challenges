package com.example.ratelimiter;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertFalse;
import static org.junit.jupiter.api.Assertions.assertTrue;

class RateLimiterTest {

    @Test
    void firstRequestIsAllowed() {
        RateLimiter limiter = new RateLimiter(3, 10);
        assertTrue(limiter.allow("alice", 100));
    }

    @Test
    void requestsUpToMaxAreAllowed() {
        RateLimiter limiter = new RateLimiter(3, 10);
        assertTrue(limiter.allow("alice", 100));
        assertTrue(limiter.allow("alice", 101));
        assertTrue(limiter.allow("alice", 102));
    }

    @Test
    void requestOverLimitIsDenied() {
        RateLimiter limiter = new RateLimiter(3, 10);
        limiter.allow("alice", 100);
        limiter.allow("alice", 101);
        limiter.allow("alice", 102);

        assertFalse(limiter.allow("alice", 103));
    }

    @Test
    void denialsStaySticky() {
        RateLimiter limiter = new RateLimiter(3, 10);
        limiter.allow("alice", 100);
        limiter.allow("alice", 101);
        limiter.allow("alice", 102);

        assertFalse(limiter.allow("alice", 103));
        assertFalse(limiter.allow("alice", 103));
    }

    @Test
    void afterWindowElapsesRequestIsAllowed() {
        RateLimiter limiter = new RateLimiter(3, 10);
        limiter.allow("alice", 100);
        limiter.allow("alice", 101);
        limiter.allow("alice", 102);

        assertTrue(limiter.allow("alice", 110));
    }

    @Test
    void newWindowResetsCount() {
        RateLimiter limiter = new RateLimiter(3, 10);
        limiter.allow("alice", 100);
        limiter.allow("alice", 101);
        limiter.allow("alice", 102);

        assertTrue(limiter.allow("alice", 110));
        assertTrue(limiter.allow("alice", 111));
        assertTrue(limiter.allow("alice", 112));
        assertFalse(limiter.allow("alice", 113));
    }

    @Test
    void boundaryIsStrict() {
        RateLimiter limiter = new RateLimiter(3, 10);
        limiter.allow("alice", 100);
        limiter.allow("alice", 101);
        limiter.allow("alice", 102);

        assertFalse(limiter.allow("alice", 109));
        assertTrue(limiter.allow("alice", 110));
    }

    @Test
    void twoClientsAreIndependent() {
        RateLimiter limiter = new RateLimiter(3, 10);
        limiter.allow("alice", 100);
        limiter.allow("alice", 101);
        limiter.allow("alice", 102);

        assertTrue(limiter.allow("bob", 102));
    }

    @Test
    void twoClientsHaveIndependentWindows() {
        RateLimiter limiter = new RateLimiter(3, 10);
        limiter.allow("alice", 100);
        limiter.allow("bob", 200);

        assertTrue(limiter.allow("alice", 205));
        assertTrue(limiter.allow("bob", 205));
    }

    @Test
    void differentConfigWorks() {
        RateLimiter limiter = new RateLimiter(1, 5);
        assertTrue(limiter.allow("x", 100));
        assertFalse(limiter.allow("x", 100));
        assertFalse(limiter.allow("x", 104));
        assertTrue(limiter.allow("x", 105));
    }
}
