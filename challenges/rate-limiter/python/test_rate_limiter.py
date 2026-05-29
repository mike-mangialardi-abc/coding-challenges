from rate_limiter import RateLimiter


def test_first_request_is_allowed():
    limiter = RateLimiter(3, 10)
    assert limiter.allow("alice", 100) is True


def test_requests_up_to_max_are_allowed():
    limiter = RateLimiter(3, 10)
    assert limiter.allow("alice", 100) is True
    assert limiter.allow("alice", 101) is True
    assert limiter.allow("alice", 102) is True


def test_request_over_limit_is_denied():
    limiter = RateLimiter(3, 10)
    limiter.allow("alice", 100)
    limiter.allow("alice", 101)
    limiter.allow("alice", 102)

    assert limiter.allow("alice", 103) is False


def test_denials_stay_sticky():
    limiter = RateLimiter(3, 10)
    limiter.allow("alice", 100)
    limiter.allow("alice", 101)
    limiter.allow("alice", 102)

    assert limiter.allow("alice", 103) is False
    assert limiter.allow("alice", 103) is False


def test_after_window_elapses_request_is_allowed():
    limiter = RateLimiter(3, 10)
    limiter.allow("alice", 100)
    limiter.allow("alice", 101)
    limiter.allow("alice", 102)

    assert limiter.allow("alice", 110) is True


def test_new_window_resets_count():
    limiter = RateLimiter(3, 10)
    limiter.allow("alice", 100)
    limiter.allow("alice", 101)
    limiter.allow("alice", 102)

    assert limiter.allow("alice", 110) is True
    assert limiter.allow("alice", 111) is True
    assert limiter.allow("alice", 112) is True
    assert limiter.allow("alice", 113) is False


def test_boundary_is_strict():
    limiter = RateLimiter(3, 10)
    limiter.allow("alice", 100)
    limiter.allow("alice", 101)
    limiter.allow("alice", 102)

    assert limiter.allow("alice", 109) is False
    assert limiter.allow("alice", 110) is True


def test_two_clients_are_independent():
    limiter = RateLimiter(3, 10)
    limiter.allow("alice", 100)
    limiter.allow("alice", 101)
    limiter.allow("alice", 102)

    assert limiter.allow("bob", 102) is True


def test_two_clients_have_independent_windows():
    limiter = RateLimiter(3, 10)
    limiter.allow("alice", 100)
    limiter.allow("bob", 200)

    assert limiter.allow("alice", 205) is True
    assert limiter.allow("bob", 205) is True


def test_different_config_works():
    limiter = RateLimiter(1, 5)
    assert limiter.allow("x", 100) is True
    assert limiter.allow("x", 100) is False
    assert limiter.allow("x", 104) is False
    assert limiter.allow("x", 105) is True
