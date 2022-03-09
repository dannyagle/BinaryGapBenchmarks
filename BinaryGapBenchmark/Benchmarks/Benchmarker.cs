using BenchmarkDotNet.Attributes;
using BinaryGap;

namespace BinaryGapBenchmark.Benchmarks;

[MemoryDiagnoser]
public class Benchmarker
{
    private readonly Gap _gapService;
    private const int _value = 32;

    public Benchmarker()
    {
        _gapService = new Gap();
    }

    [Benchmark]
    public void Shift()
    {
        _gapService.ShiftSolution(_value);
    }

    [Benchmark]
    public void Linq()
    {
        _gapService.LinqSolution(_value);
    }

    [Benchmark]
    public void Array()
    {
        _gapService.ArraySolution(_value);
    }

}
