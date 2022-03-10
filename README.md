# BinaryGapBenchmarks
Perform benchmarks on various binary gap solutions

This is a .net6 project.

# The binary gap challenge:
- Expect an integer between 1 and 2,147,483,647
- Convert that integer into its binary value
- Return the length of the largest sequence of zeros between ones
- Return 0 if no zeros between ones

I have seen a variety of *challenges*; some where the ones need to be considered and others only zeroes.  I went with only zeroes.

# Summary
```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 7 3700X, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.200
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT


|     Method |       Mean |     Error |    StdDev |  Gen 0 | Allocated |
|----------- |-----------:|----------:|----------:|-------:|----------:|
|      Array |  37.984 ns | 0.4086 ns | 0.3822 ns | 0.0095 |      80 B |
|       Linq | 147.280 ns | 0.9056 ns | 0.8471 ns | 0.0048 |      40 B |
|      Shift |  16.726 ns | 0.1435 ns | 0.1342 ns |      - |         - |
| ShiftRight |   2.648 ns | 0.0138 ns | 0.0123 ns |      - |         - |

```

It's no surprise than using the bit shift operator performs the fastest.

It was a little surprising to me that the char array method performed as well as it did... only twice as long as the bit shift.  And even more surprising that it alocated more memory on the Heap than the LINQ solution.  However, it's so much faster than the LINQ version that the hit we will take from garbage collection is probably not relevant.  Perhaps it can be tweaked... all these methods were thrown together rather quickly.

Linq, as I expected, performed the worst taking nearly 10x as long as the shifts.  Again, there is probably room for improvements.  I tried to help it by trimming non-gap values off the front and back but maybe it just hurt it.

# Update
ZQ added the ShiftRight method (as opposed to my shift method which is LeftShift).  I updated the summary.  It is a massive performance improvement!

