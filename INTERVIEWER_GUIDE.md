# Interviewer Guide

This guide applies to **all three challenges** in this repo. Read it once before your first interview.

> **DO NOT share this file (or any `INTERVIEWER.md`) with the candidate.** Both contain the reference solution and hint ladder.

---

## What we're evaluating

A candidate at the entry-level bar should be able to:

1. **Read and understand requirements.** Re-read the problem statement when they get stuck. Ask clarifying questions about anything genuinely ambiguous.
2. **Apply programming fundamentals.** Use the language's standard library competently — maps/dictionaries, lists, conditionals, simple arithmetic. They do not need to know clever algorithms.
3. **Run and use the tests.** Run the failing test suite at least once before writing code. Use test failures to guide their work. Run tests again before declaring "done."
4. **Communicate while working.** Think out loud. Explain the approach in a sentence or two before coding. Ask questions instead of silently guessing.

We are **not** evaluating:

- Speed of typing
- Knowledge of obscure language features
- Optimal Big-O (these problems are not algorithmically interesting)
- Whether they finish — partial-but-correct is fine

## Rubric

Score each axis from 1 (concerning) to 4 (strong). A solid hire is mostly 3s with no 1s.

| Axis | 1 | 2 | 3 | 4 |
| --- | --- | --- | --- | --- |
| **Requirements comprehension** | Misreads the spec, ignores README. | Reads but misses an edge case. | Reads carefully, asks one clarifying question. | Reads, re-reads when stuck, summarises the spec back unprompted. |
| **Code clarity** | Tangled, unclear naming. | Works but cluttered. | Readable, idiomatic for the language. | Clean, well-named, easy to review. |
| **Use of tests** | Doesn't run tests until end. | Runs tests once or twice. | Runs tests iteratively, reads failures. | Uses tests as the spec; debugs from failures methodically. |
| **Communication** | Silent or evasive. | Answers when asked. | Narrates approach, asks good questions. | Drives the conversation, explains tradeoffs. |
| **Recovery from being stuck** | Freezes; needs solution given. | Gets unstuck after multiple strong hints. | Gets unstuck after a small nudge. | Self-recovers by re-reading spec or tests. |

## Pacing — what to expect

These challenges target **20–30 minutes of coding time**, plus a few minutes of setup and a few minutes of follow-up discussion. Total interview block: ~45 minutes.

Rough pacing:

- **0–3 min** — Candidate clones the repo, installs deps, runs tests (you should see them go red).
- **3–8 min** — Candidate reads the README and the stub class. Encourage them to ask questions.
- **8–25 min** — Coding.
- **25–30 min** — Final test run, light cleanup.
- **30–40 min** — Stretch task or follow-up questions from `INTERVIEWER.md`.

If a candidate is still on setup at the 10-minute mark, help them past it — setup struggles are not what we're testing.

## How to deliver a challenge

1. Ahead of the interview: confirm which language the candidate prefers and confirm they have that language's toolchain installed (see [README.md](README.md)).
2. At interview start: share **just** the `challenges/<challenge>/` folder. The easiest way is to send them a zip of that folder, or a fork of this repo with the other challenges (and all `INTERVIEWER.md` files) deleted.
3. Have them screen-share their full IDE. They should be able to run tests locally — do **not** force them into an unfamiliar online sandbox.

## When to offer a hint

The hint ladder lives in each challenge's `INTERVIEWER.md`. Walk down it gradually:

1. First, re-pose the failing test as a question: "What does that test expect when you pass `X`?"
2. Then nudge toward the relevant part of the README they may have skimmed.
3. Only then give the structural hint.
4. Reveal the solution only if the candidate is fully stuck and time is up — and note this in your feedback.

Hinting is normal. A candidate who needs one hint and then drives forward is still a strong signal.

## Common pitfalls (all three challenges)

- **Doesn't run the tests first** — gently ask them to run the suite before writing code.
- **Reads the stub class but not the candidate README** — point them at the README.
- **Fights the language's standard library** instead of using it — okay to suggest "is there a built-in for that?"
- **Tries to handle imaginary edge cases** (network failure, threading) — redirect to what the tests actually check.

## After the interview

Capture:

- Which challenge + which language
- Test result at the time you stopped (X/Y passing)
- Rubric scores
- One paragraph of qualitative notes — especially how they reacted to being stuck
- Any hints you gave (which step of the ladder)
