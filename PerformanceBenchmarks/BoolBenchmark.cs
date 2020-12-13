using BenchmarkDotNet.Attributes;

namespace PerformanceBenchmarks
{
    [Config(typeof(Config))]
    public class BoolBenchmark
    {
        [Benchmark]
        public string DotToString() => true.ToString();

        [Benchmark]
        public string TrueString() => bool.TrueString;
    }
}
