using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace PerformanceBenchmarks
{
    [Config(typeof(Config))]
    [ShortRunJob]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class SingleVsFirstVsFindBenchmark
    {
        private readonly List<string> _haystack = new List<string>();
        private const int HaystackSize = 1000000;
        private const string Needle = "needle";

        public SingleVsFirstVsFindBenchmark()
        {
            Enumerable.Range(1, HaystackSize).ToList().ForEach(x => _haystack.Add(x.ToString()));
            _haystack.Insert(HaystackSize / 2, Needle);
        }

        [Benchmark]
        public string Single() => _haystack.SingleOrDefault(x => x == Needle);

        [Benchmark]
        public string First() => _haystack.FirstOrDefault(x => x == Needle);

        [Benchmark]
        public string Find() => _haystack.Find(x => x == Needle);
    }
}
