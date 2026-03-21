# Top 20 Senior Backend Coding Round Tasks

A curated list of 20 coding challenges commonly encountered in FAANG-level backend engineering interviews.

## Progress Tracker

| # | Task | Difficulty | Status |
|---|------|------------|--------|
| 1 | [Time-Based Key-Value Store](https://leetcode.com/problems/time-based-key-value-store/) | Medium | ✅ Done |
| 2 | [Median from Data Stream](https://leetcode.com/problems/find-median-from-data-stream/) | Hard | ✅ Done |
| 3 | [Sliding Window Maximum](https://leetcode.com/problems/sliding-window-maximum/) | Hard | ✅ Done |
| 4 | [Kth Largest Element in Stream](https://leetcode.com/problems/kth-largest-element-in-a-stream/) | Easy | ✅ Done |
| 5 | [LFU Cache](https://leetcode.com/problems/lfu-cache/) | Hard | ✅ Done |
| 6 | [All O(1) Data Structure](https://leetcode.com/problems/all-oone-data-structure/) | Hard | ⬜ Todo |
| 7 | [Minimum Window Substring](https://leetcode.com/problems/minimum-window-substring/) | Hard | ⬜ Todo |
| 8 | [Longest Substring with K Distinct Characters](https://leetcode.com/problems/longest-substring-with-at-most-k-distinct-characters/) | Medium | ⬜ Todo |
| 9 | [Top K Frequent Elements](https://leetcode.com/problems/top-k-frequent-elements/) | Medium | ⬜ Todo |
| 10 | [Task Scheduler](https://leetcode.com/problems/task-scheduler/) | Medium | ⬜ Todo |
| 11 | [Course Schedule II](https://leetcode.com/problems/course-schedule-ii/) | Medium | ⬜ Todo |
| 12 | [Clone Graph](https://leetcode.com/problems/clone-graph/) | Medium | ⬜ Todo |
| 13 | [Serialize / Deserialize Binary Tree](https://leetcode.com/problems/serialize-and-deserialize-binary-tree/) | Hard | ⬜ Todo |
| 14 | [Lowest Common Ancestor](https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/) | Medium | ⬜ Todo |
| 15 | [Meeting Rooms II](https://leetcode.com/problems/meeting-rooms-ii/) | Medium | ⬜ Todo |
| 16 | [Insert Interval](https://leetcode.com/problems/insert-interval/) | Medium | ⬜ Todo |
| 17 | Design Rate Limiter | Medium | ⬜ Todo |
| 18 | [Design Hit Counter](https://leetcode.com/problems/design-hit-counter/) | Medium | ⬜ Todo |
| 19 | [Design In-Memory File System](https://leetcode.com/problems/design-in-memory-file-system/) | Hard | ⬜ Todo |
| 20 | [Autocomplete System](https://leetcode.com/problems/design-search-autocomplete-system/) | Hard | ⬜ Todo |
| 21 | [LRU Cache](https://leetcode.com/problems/lru-cache/) | Medium | ✅ Done |

---

## Data Structures & Caches

### 1. Time-Based Key-Value Store [#981](https://leetcode.com/problems/time-based-key-value-store/) (Medium)
Implement a data structure that supports:
- `set(key, value, timestamp)` — stores the value for a key at a specific timestamp
- `get(key, timestamp)` — returns the value with the largest timestamp ≤ given timestamp

### 2. Median from Data Stream [#295](https://leetcode.com/problems/find-median-from-data-stream/) (Hard)
Design a data structure that supports:
- `addNum(num)` — adds a number to the data stream
- `findMedian()` — returns the median of all numbers so far

### 4. Kth Largest Element in Stream [#703](https://leetcode.com/problems/kth-largest-element-in-a-stream/) (Easy)
Design a data structure that supports:
- `add(val)` — adds a value to the stream
- `getKthLargest()` — returns the k-th largest element

### 5. LFU Cache [#460](https://leetcode.com/problems/lfu-cache/) (Hard)
Implement a cache with operations:
- `get(key)`
- `put(key, value)`

Evict the **least frequently used** element when capacity is exceeded.

### 21. LRU Cache [#146](https://leetcode.com/problems/lru-cache/) (Medium)
Implement a cache with operations:
- `get(key)` — returns the value if it exists, otherwise `-1`
- `put(key, value)` — inserts or updates the key; evict the **least recently used** entry when capacity is exceeded

> Both operations must run in **O(1)**.

### 6. All O(1) Data Structure [#432](https://leetcode.com/problems/all-oone-data-structure/) (Hard)
Design a data structure that supports:
- `inc(key)`
- `dec(key)`
- `getMaxKey()`
- `getMinKey()`

> All operations must run in **O(1)**.

---

## Arrays & Sliding Window

### 3. Sliding Window Maximum [#239](https://leetcode.com/problems/sliding-window-maximum/) (Hard)
Given an array of integers and a window size `k`, return the maximum value in each sliding window.

### 7. Minimum Window Substring [#76](https://leetcode.com/problems/minimum-window-substring/) (Hard)
Given strings `s` and `t`, find the minimum substring of `s` that contains all characters of `t`.

### 8. Longest Substring with K Distinct Characters [#340](https://leetcode.com/problems/longest-substring-with-at-most-k-distinct-characters/) (Medium)
Find the longest substring containing at most `K` distinct characters.

### 9. Top K Frequent Elements [#347](https://leetcode.com/problems/top-k-frequent-elements/) (Medium)
Given an array, return the `k` most frequent elements.

### 10. Task Scheduler [#621](https://leetcode.com/problems/task-scheduler/) (Medium)
Given a list of tasks and a cooldown `n`, find the minimum total time to execute all tasks.

---

## Graphs & Trees

### 11. Course Schedule II [#210](https://leetcode.com/problems/course-schedule-ii/) (Medium)
Given a graph of course prerequisites, return a valid order of course completion (topological sort).

### 12. Clone Graph [#133](https://leetcode.com/problems/clone-graph/) (Medium)
Given a graph (possibly with cycles), return a deep copy of it.

### 13. Serialize / Deserialize Binary Tree [#297](https://leetcode.com/problems/serialize-and-deserialize-binary-tree/) (Hard)
Implement:
- `serialize(root)` — converts a binary tree to a string
- `deserialize(data)` — reconstructs the tree from the string

### 14. Lowest Common Ancestor [#236](https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/) (Medium)
Given a binary tree and two nodes, find their **Lowest Common Ancestor (LCA)**.

---

## Intervals

### 15. Meeting Rooms II [#253](https://leetcode.com/problems/meeting-rooms-ii/) (Medium)
Given a list of meeting intervals, find the **minimum number of rooms** required.

### 16. Insert Interval [#57](https://leetcode.com/problems/insert-interval/) (Medium)
Insert a new interval into a sorted list of intervals and merge any overlapping intervals.

---

## System Design (Coding)

### 17. Design Rate Limiter (Medium)
Implement:
- `allow(user_id)` — returns whether the request should be allowed

Use one of: **Token Bucket**, **Sliding Window**, or **Leaky Bucket** algorithm.

### 18. Design Hit Counter [#362](https://leetcode.com/problems/design-hit-counter/) (Medium)
Implement:
- `hit(timestamp)` — records a hit at the given timestamp
- `getHits(timestamp)` — returns the number of hits in the **last 5 minutes**

### 19. Design In-Memory File System [#588](https://leetcode.com/problems/design-in-memory-file-system/) (Hard)
Implement an API with:
- `ls(path)`
- `mkdir(path)`
- `addFile(path, content)`
- `readFile(path)`

### 20. Autocomplete System [#642](https://leetcode.com/problems/design-search-autocomplete-system/) (Hard)
Implement:
- `input(char)` — returns the **top 3 suggestions by frequency** as the user types
