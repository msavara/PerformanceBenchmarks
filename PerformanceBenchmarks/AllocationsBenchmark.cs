using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace PerformanceBenchmarks
{
    [Config(typeof(Config))]
    [ShortRunJob]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class AllocationsBenchmark
    {
        //[Benchmark(Description = "HashSet<string>")]
        //public HashSet<string> HashSetString() => new HashSet<string>();

        //[Benchmark(Description = "SortedDictionary<string, string>")]
        //public SortedDictionary<string, string> SortedDictionaryString() => new SortedDictionary<string, string>();

        //[Benchmark(Description = "SortedList<string, string>")]
        //public SortedList<string, string> SortedListString() => new SortedList<string, string>();

        //[Benchmark(Description = "StringBuilder")]
        //public StringBuilder StringBuilder() => new StringBuilder();

        [Benchmark]
        public byte[] EightBytes() => new byte[8];

        [Benchmark]
        public byte[] SixteenBytes() => new byte[16];
    }
}