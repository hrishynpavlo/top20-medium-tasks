# Top 20 Senior Backend Coding Round Tasks

A curated list of 20 coding challenges commonly encountered in FAANG-level backend engineering interviews.

---

## Data Structures & Caches

### 1. Time-Based Key-Value Store
Implement a data structure that supports:
- `set(key, value, timestamp)` — stores the value for a key at a specific timestamp
- `get(key, timestamp)` — returns the value with the largest timestamp ≤ given timestamp

### 2. Median from Data Stream
Design a data structure that supports:
- `addNum(num)` — adds a number to the data stream
- `findMedian()` — returns the median of all numbers so far

### 4. Kth Largest Element in Stream
Design a data structure that supports:
- `add(val)` — adds a value to the stream
- `getKthLargest()` — returns the k-th largest element

### 5. LFU Cache
Implement a cache with operations:
- `get(key)`
- `put(key, value)`

Evict the **least frequently used** element when capacity is exceeded.

### 21. LRU Cache
Implement a cache with operations:
- `get(key)` — returns the value if it exists, otherwise `-1`
- `put(key, value)` — inserts or updates the key; evict the **least recently used** entry when capacity is exceeded

> Both operations must run in **O(1)**.

### 6. All O(1) Data Structure
Design a data structure that supports:
- `inc(key)`
- `dec(key)`
- `getMaxKey()`
- `getMinKey()`

> All operations must run in **O(1)**.

---

## Arrays & Sliding Window

### 3. Sliding Window Maximum
Given an array of integers and a window size `k`, return the maximum value in each sliding window.

### 7. Minimum Window Substring
Given strings `s` and `t`, find the minimum substring of `s` that contains all characters of `t`.

### 8. Longest Substring with K Distinct Characters
Find the longest substring containing at most `K` distinct characters.

### 9. Top K Frequent Elements
Given an array, return the `k` most frequent elements.

### 10. Task Scheduler
Given a list of tasks and a cooldown `n`, find the minimum total time to execute all tasks.

---

## Graphs & Trees

### 11. Course Schedule II
Given a graph of course prerequisites, return a valid order of course completion (topological sort).

### 12. Clone Graph
Given a graph (possibly with cycles), return a deep copy of it.

### 13. Serialize / Deserialize Binary Tree
Implement:
- `serialize(root)` — converts a binary tree to a string
- `deserialize(data)` — reconstructs the tree from the string

### 14. Lowest Common Ancestor
Given a binary tree and two nodes, find their **Lowest Common Ancestor (LCA)**.

---

## Intervals

### 15. Meeting Rooms II
Given a list of meeting intervals, find the **minimum number of rooms** required.

### 16. Insert Interval
Insert a new interval into a sorted list of intervals and merge any overlapping intervals.

---

## System Design (Coding)

### 17. Design Rate Limiter
Implement:
- `allow(user_id)` — returns whether the request should be allowed

Use one of: **Token Bucket**, **Sliding Window**, or **Leaky Bucket** algorithm.

### 18. Design Hit Counter
Implement:
- `hit(timestamp)` — records a hit at the given timestamp
- `getHits(timestamp)` — returns the number of hits in the **last 5 minutes**

### 19. Design In-Memory File System
Implement an API with:
- `ls(path)`
- `mkdir(path)`
- `addFile(path, content)`
- `readFile(path)`

### 20. Autocomplete System
Implement:
- `input(char)` — returns the **top 3 suggestions by frequency** as the user types

---

## Progress Tracker

| # | Task | Status |
|---|------|--------|
| 1 | Time-Based Key-Value Store | ✅ Done |
| 2 | Median from Data Stream | ⬜ Todo |
| 3 | Sliding Window Maximum | ⬜ Todo |
| 4 | Kth Largest Element in Stream | ⬜ Todo |
| 5 | LFU Cache | ⬜ Todo |
| 6 | All O(1) Data Structure | ⬜ Todo |
| 7 | Minimum Window Substring | ⬜ Todo |
| 8 | Longest Substring with K Distinct Characters | ⬜ Todo |
| 9 | Top K Frequent Elements | ⬜ Todo |
| 10 | Task Scheduler | ⬜ Todo |
| 11 | Course Schedule II | ⬜ Todo |
| 12 | Clone Graph | ⬜ Todo |
| 13 | Serialize / Deserialize Binary Tree | ⬜ Todo |
| 14 | Lowest Common Ancestor | ⬜ Todo |
| 15 | Meeting Rooms II | ⬜ Todo |
| 16 | Insert Interval | ⬜ Todo |
| 17 | Design Rate Limiter | ⬜ Todo |
| 18 | Design Hit Counter | ⬜ Todo |
| 19 | Design In-Memory File System | ⬜ Todo |
| 20 | Autocomplete System | ⬜ Todo |
| 21 | LRU Cache | ✅ Done |
