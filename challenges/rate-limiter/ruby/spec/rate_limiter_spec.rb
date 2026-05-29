RSpec.describe RateLimiter do
  it "allows the first request" do
    limiter = RateLimiter.new(3, 10)
    expect(limiter.allow("alice", 100)).to eq(true)
  end

  it "allows requests up to the max" do
    limiter = RateLimiter.new(3, 10)
    expect(limiter.allow("alice", 100)).to eq(true)
    expect(limiter.allow("alice", 101)).to eq(true)
    expect(limiter.allow("alice", 102)).to eq(true)
  end

  it "denies a request over the limit" do
    limiter = RateLimiter.new(3, 10)
    limiter.allow("alice", 100)
    limiter.allow("alice", 101)
    limiter.allow("alice", 102)

    expect(limiter.allow("alice", 103)).to eq(false)
  end

  it "keeps denials sticky inside the same window" do
    limiter = RateLimiter.new(3, 10)
    limiter.allow("alice", 100)
    limiter.allow("alice", 101)
    limiter.allow("alice", 102)

    expect(limiter.allow("alice", 103)).to eq(false)
    expect(limiter.allow("alice", 103)).to eq(false)
  end

  it "allows a request after the window elapses" do
    limiter = RateLimiter.new(3, 10)
    limiter.allow("alice", 100)
    limiter.allow("alice", 101)
    limiter.allow("alice", 102)

    expect(limiter.allow("alice", 110)).to eq(true)
  end

  it "resets the count on a new window" do
    limiter = RateLimiter.new(3, 10)
    limiter.allow("alice", 100)
    limiter.allow("alice", 101)
    limiter.allow("alice", 102)

    expect(limiter.allow("alice", 110)).to eq(true)
    expect(limiter.allow("alice", 111)).to eq(true)
    expect(limiter.allow("alice", 112)).to eq(true)
    expect(limiter.allow("alice", 113)).to eq(false)
  end

  it "uses a strict boundary (>= windowSeconds opens a new window)" do
    limiter = RateLimiter.new(3, 10)
    limiter.allow("alice", 100)
    limiter.allow("alice", 101)
    limiter.allow("alice", 102)

    expect(limiter.allow("alice", 109)).to eq(false)
    expect(limiter.allow("alice", 110)).to eq(true)
  end

  it "treats clients independently" do
    limiter = RateLimiter.new(3, 10)
    limiter.allow("alice", 100)
    limiter.allow("alice", 101)
    limiter.allow("alice", 102)

    expect(limiter.allow("bob", 102)).to eq(true)
  end

  it "gives each client an independent window" do
    limiter = RateLimiter.new(3, 10)
    limiter.allow("alice", 100)
    limiter.allow("bob", 200)

    expect(limiter.allow("alice", 205)).to eq(true)
    expect(limiter.allow("bob", 205)).to eq(true)
  end

  it "works with a different config" do
    limiter = RateLimiter.new(1, 5)
    expect(limiter.allow("x", 100)).to eq(true)
    expect(limiter.allow("x", 100)).to eq(false)
    expect(limiter.allow("x", 104)).to eq(false)
    expect(limiter.allow("x", 105)).to eq(true)
  end
end
