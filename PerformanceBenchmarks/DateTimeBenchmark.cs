using System;
using BenchmarkDotNet.Attributes;

namespace PerformanceBenchmarks
{
    [Config(typeof(Config))]
    public class DateTimeBenchmark
    {
        private DateTime _dateNow;
        private DateTimeOffset _dateOffset;

        [Benchmark]
        public void DateTime_Now()
        {
            _dateNow = DateTime.Now;
        }

        [Benchmark]
        public void DateTime_Utc()
        {
            _dateNow = DateTime.UtcNow;
        }

        [Benchmark]
        public void DateTimeOffset_Now()
        {
            _dateOffset = DateTimeOffset.Now;
        }

        [Benchmark]
        public void DateTimeOffset_Utc()
        {
            _dateOffset = DateTimeOffset.UtcNow;
        }
    }
}