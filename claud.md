# Project Guidelines

## Code Style
- Slim code, short comments
- DRY, single-use, minimal code

## Abstraction
- Prefer abstractions (e.g. wrapper functions) at higher levels
- Lower-level code can be more detailed, but single-use remains a priority

## Workflow
- Pause after features to revisit architecture or do refactor/cleanup when warranted


This app uses zoneless change detection (provideZonelessChangeDetection()), so use Angular signals to trigger re-renders, do not rely on zone change detection