using BenchmarkDotNet.Running;
using BinaryGapBenchmark.Benchmarks;

// remember to change this to Release...

BenchmarkRunner.Run<Benchmarker>();