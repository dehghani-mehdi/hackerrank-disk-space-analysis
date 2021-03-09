# Hacker Rank - Disk Space Analysis
C# solution for HackerRank's Disk space analysis challenge.

## Example
For following array `[2, 5, 4, 6, 8]` with `x = 3`, the answer is `4` _see below_

The chunks would be:
- `[2, 5, 4]` -> min: `2`
- `[5, 4, 6]` -> min: `4`
- `[4, 6, 8]` -> min: `4`

## Solution
1. Find minimum for first chunk
2. For next chunks 2 different situations could happen


#### The prev. found minimum is part of current chunk
In this case we just need to compare current number with prev. found minimum, hence code below
```
s.Push(space[i] < space[peek] ? i: peek);
```
#### The prev. found minimum is NOT part of current chunk
In this case we have to loop through current chunk to find the minimum
```
s.Push(i);

var j = chunkNum;
var count = 0;
while (count++ < x)
{
    if (space[j] < space[s.Peek()])
    {
        s.Pop();
        s.Push(j);
    }
    j++;
}
```

3. Find the maximum between found minimums, thanks to LINQ, it is dead easy
```
s.Select(c => space[c]).Max();
```

## Test

```
var n = 1000000;
var rnd = new Random();
var x = rnd.Next(1, n);
var testcase = new int[n];
for (int i = 0; i < n; i++) testcase[i] = rnd.Next(1, 1000000000);	

var sw = new Stopwatch();
sw.Start();
var max = FindMax(testcase, x);
sw.Stop();
Console.WriteLine(sw.Elapsed.TotalMilliseconds);
```

Result for 10 times: (_CPU Corei7-3370_)
```
50.3968 ms
49.7836 ms
51.6996 ms
48.6897 ms
50.2987 ms
52.1221 ms
57.2268 ms
49.3892 ms
50.8927 ms
49.2455 ms
```

---

If you find a testcase which this code doesn't works for, or you find any other problem, please file an issue.
