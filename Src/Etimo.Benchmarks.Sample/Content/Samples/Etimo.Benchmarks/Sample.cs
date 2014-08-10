using System;
using System.Collections.Generic;
using System.Linq;
using Etimo.Benchmarks.Interfaces.Results;
using Etimo.Benchmarks.Processors;
using Samples.Etimo.Benchmarks.CollectionBenchmarks.BenchmarkBase.BenchmarkComponents;
using Samples.Etimo.Benchmarks.CollectionBenchmarks.BenchmarkBase.BenchmarkComponents.KeyedCollection;
using Samples.Etimo.Benchmarks.CollectionBenchmarks.BenchmarkBase.BenchmarkComponents.MultiplyIndexedKeyedCollection;
using Samples.Etimo.Benchmarks.Data;

namespace Samples.Etimo.Benchmarks
{
    public class Sample
    {
        public static void RunSample()
        {
            IList<CountryOrRegionGdpData> listData = new DataImporter().Import();

            Func<BenchmarkComponentBase>[] benchmarkComponents =
            {
                () => new BenchmarkComponentKeyedCollection(listData),
                () => new BenchmarkComponentMultiplyIndexedKeyedCollection(listData),
            };

            BenchmarkProcessor benchmarkProcessor = new BenchmarkProcessor();

            BenchmarkProcessorConfiguration benchmarkProcessorConfiguration = new BenchmarkProcessorConfiguration();

            IEnumerable<IBenchmarkComponentResult> benchmarkResults = benchmarkProcessor.Execute(benchmarkProcessorConfiguration, benchmarkComponents);

            foreach (IBenchmarkComponentResult benchmarkComponentResult in benchmarkResults)
                Console.WriteLine("Benchmark Component: {0}{1}{2}", benchmarkComponentResult.Name, Environment.NewLine, FormatBenchmarkResults(benchmarkComponentResult.RootOperationResult, 0));

            Console.ReadLine();
        }

        private static string FormatBenchmarkResults(IOperationResultBase benchmarkResult, int nestingLevel)
        {
            string formattedResults = nestingLevel == 0 ? "" : new string('-', nestingLevel * 3) + '→' + ' ';
            string label = benchmarkResult is IOperationGroupResult ? benchmarkResult.Name + " (Group Total)" : benchmarkResult.Name;

            formattedResults += string.Format("{0}: {1}", label.PadRight(22), benchmarkResult.Durations.Min.TotalMilliseconds.ToString("0.000 ms.").PadLeft(12));

            if (benchmarkResult is IOperationWithFuncResult)
                formattedResults += string.Format("{0}Return Value: {1}", new string(' ', 3), ((IOperationWithFuncResult)benchmarkResult).FuncReturnValue);

            if (benchmarkResult is IOperationGroupResult)
            {
                IOperationGroupResult benchmarkResultTyped = (IOperationGroupResult)benchmarkResult;

                foreach (IOperationResultBase childOperationResult in benchmarkResultTyped.ChildOperationResults)
                {
                    formattedResults += Environment.NewLine + FormatBenchmarkResults(childOperationResult, nestingLevel + 1);
                }
            }

            return formattedResults;
        }
    }
}