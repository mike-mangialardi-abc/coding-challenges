# Rate Limiter — Python

## Prerequisites

- Python 3.11+
- `pip`

A virtual environment is recommended:

```bash
python -m venv .venv
source .venv/bin/activate   # on Windows: .venv\Scripts\activate
```

## Install dependencies and run tests

```bash
pip install -r requirements.txt
pytest
```

You should initially see **10 failing tests**. Your goal is to make them all pass by implementing `RateLimiter` in `rate_limiter.py`.

## Files

- `rate_limiter.py` — the class you need to implement.
- `test_rate_limiter.py` — the test suite. Do not modify.
- `requirements.txt` — pinned pytest version. Do not modify.

## Reminder

Read the **problem statement** at `../README.md` first.
