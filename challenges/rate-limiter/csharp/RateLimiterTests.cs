using Xunit;

namespace RateLimiterChallenge;

public class RateLimiterTests
{
    [Fact]
    public void FirstRequest_IsAllowed()
    {
        var limiter = new RateLimiter(3, 10);
        Assert.True(limiter.Allow("alice", 100));
    }

    [Fact]
    public void RequestsUpToMax_AreAllowed()
    {
        var limiter = new RateLimiter(3, 10);
        Assert.True(limiter.Allow("alice", 100));
        Assert.True(limiter.Allow("alice", 101));
        Assert.True(limiter.Allow("alice", 102));
    }

    [Fact]
    public void RequestOverMax_IsDenied()
    {
        var limiter = new RateLimiter(3, 10);
        limiter.Allow("alice", 100);
        limiter.Allow("alice", 101);
        limiter.Allow("alice", 102);

        Assert.False(limiter.Allow("alice", 103));
    }

    [Fact]
    public void DenialsStaySticky_NoSuddenAllow()
    {
        var limiter = new RateLimiter(3, 10);
        limiter.Allow("alice", 100);
        limiter.Allow("alice", 101);
        limiter.Allow("alice", 102);

        Assert.False(limiter.Allow("alice", 103));
        Assert.False(limiter.Allow("alice", 103));
    }

    [Fact]
    public void AfterWindowElapses_RequestIsAllowed()
    {
        var limiter = new RateLimiter(3, 10);
        limiter.Allow("alice", 100);
        limiter.Allow("alice", 101);
        limiter.Allow("alice", 102);

        // window started at 100, length 10 -> new window at 110.
        Assert.True(limiter.Allow("alice", 110));
    }

    [Fact]
    public void NewWindow_ResetsCount()
    {
        var limiter = new RateLimiter(3, 10);
        limiter.Allow("alice", 100);
        limiter.Allow("alice", 101);
        limiter.Allow("alice", 102);

        Assert.True(limiter.Allow("alice", 110));
        Assert.True(limiter.Allow("alice", 111));
        Assert.True(limiter.Allow("alice", 112));
        Assert.False(limiter.Allow("alice", 113));
    }

    [Fact]
    public void Boundary_IsStrict()
    {
        var limiter = new RateLimiter(3, 10);
        limiter.Allow("alice", 100);
        limiter.Allow("alice", 101);
        limiter.Allow("alice", 102);

        // 1 second before boundary - still old window, still denied.
        Assert.False(limiter.Allow("alice", 109));
        // Exactly at boundary - new window begins.
        Assert.True(limiter.Allow("alice", 110));
    }

    [Fact]
    public void TwoClients_AreIndependent()
    {
        var limiter = new RateLimiter(3, 10);
        limiter.Allow("alice", 100);
        limiter.Allow("alice", 101);
        limiter.Allow("alice", 102);

        // alice is at limit; bob's first request must still succeed.
        Assert.True(limiter.Allow("bob", 102));
    }

    [Fact]
    public void TwoClients_HaveIndependentWindows()
    {
        var limiter = new RateLimiter(3, 10);
        // alice window starts at 100, ends at 110.
        limiter.Allow("alice", 100);
        // bob window starts at 200.
        limiter.Allow("bob", 200);

        // At t=205, alice is in her second window (well past 110),
        // and bob is in his first.
        Assert.True(limiter.Allow("alice", 205));
        Assert.True(limiter.Allow("bob", 205));
    }

    [Fact]
    public void DifferentConfig_WorksCorrectly()
    {
        var limiter = new RateLimiter(1, 5);
        Assert.True(limiter.Allow("x", 100));
        Assert.False(limiter.Allow("x", 100));
        Assert.False(limiter.Allow("x", 104));
        Assert.True(limiter.Allow("x", 105));
    }
}
