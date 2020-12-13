using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace PerformanceBenchmarks
{
    [Config(typeof(Config))]
    public class ListBenchmark
    {
        [Params(1000, 1000000)] public int N;

        [Benchmark(Baseline = true)]
        public void Array()
        {
            var array = new int[N];
            for (int i = 0; i < N; i++)
            {
                array[i] = i;
            }
        }

        [Benchmark]
        public void ListA()
        {
            var list = new List<int>(N);
            for (int i = 0; i < N; i++)
            {
                list.Add(i);
            }
        }

        [Benchmark]
        public void ListB()
        {
            var list = new List<int>();
            for (int i = 0; i < N; i++)
            {
                list.Add(i);
            }
        }

        [Benchmark]
        public void HashSet()
        {
            var set = new HashSet<int>();
            for (int i = 0; i < N; i++)
            {
                set.Add(i);
            }
        }
    }
}