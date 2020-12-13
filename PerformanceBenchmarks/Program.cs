using System;
using System.Linq;
using System.Reflection;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace PerformanceBenchmarks
{
    public static class Program
    {
        private const string Suffix = "Benchmark";

        public static void Main(string[] args)
        {
            var benchmarks = Assembly.GetEntryAssembly()
                ?.DefinedTypes.Where(t => t.Name.EndsWith(Suffix))
                .ToDictionary(t => t.Name.Substring(0, t.Name.Length - Suffix.Length), t => t, StringComparer.OrdinalIgnoreCase);

            if (args.Length > 0 && args[0].Equals("all", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Running full benchmarks suite");
                benchmarks.Select(pair => pair.Value).ToList().ForEach(action => BenchmarkRunner.Run(action));
                return;
            }

            if (benchmarks != null && (args.Length == 0 || !benchmarks.ContainsKey(args[0])))
            {
                Console.WriteLine("Please, select benchmark, list of available:");
                benchmarks
                    .Select(pair => pair.Key)
                    .ToList()
                    .ForEach(Console.WriteLine);
                Console.WriteLine("All");
                return;
            }

            if (benchmarks != null) BenchmarkRunner.Run(benchmarks[args[0]]);

            Console.ReadKey();
        }
    }

    internal class Config : ManualConfig
    {
        public Config()
        {
            AddDiagnoser(MemoryDiagnoser.Default);
            AddJob(Job.ShortRun.WithJit(Jit.RyuJit).WithPlatform(Platform.X64).WithRuntime(CoreRuntime.Core50));
            AddJob(Job.ShortRun.WithJit(Jit.RyuJit).WithPlatform(Platform.X64).WithRuntime(CoreRuntime.Core31));
            AddJob(Job.ShortRun.WithJit(Jit.RyuJit).WithPlatform(Platform.X64).WithRuntime(ClrRuntime.Net48));
            //AddDiagnoser(new DisassemblyDiagnoser(new DisassemblyDiagnoserConfig(maxDepth: 3, exportDiff: true)));
        }
    }
}