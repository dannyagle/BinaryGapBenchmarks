using BenchmarkDotNet.Attributes;

using BinaryGap;

namespace BinaryGapBenchmark.Benchmarks;

[MemoryDiagnoser]
public class Benchmarker
{
  private const int Value = 32;

  private readonly Gap _gapService;

  public Benchmarker() => _gapService = new Gap();

  [Benchmark]
  public void Array() => _gapService.ArraySolution(Value);

  [Benchmark]
  public void Linq() => _gapService.LinqSolution(Value);

  [Benchmark]
  public void Shift() => _gapService.ShiftSolution(Value);

  [Benchmark]
  public void ShiftRight() => _gapService.ShiftRightSolution(Value);
}
