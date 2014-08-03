using System;
using System.Collections.Generic;
using System.Linq;
using Etimo.Benchmarks.Interfaces.Results;
using Etimo.Benchmarks.Processors;
using Etimo.Benchmarks.Sample.Content.Benchmarks.BenchmarkBase.BenchmarkComponents;
using Etimo.Benchmarks.Sample.Content.Benchmarks.KeyedCollection;
using Etimo.Benchmarks.Sample.Content.Benchmarks.MultiplyIndexedKeyedCollection;
using Etimo.Benchmarks.Sample.Content.Data;

namespace Etimo.Benchmarks.Sample.Content
{
    public class Sample
    {
        public static void RunSample()
        {
            IList<CountryOrRegionGdpData> listData = new DataImporter().Import();

            Func<BenchmarkComponentBase>[] benchmarkComponents =
            {
                () => new BenchmarkComponentStandard(listData),
                () => new BenchmarkComponentMultiply(listData),
            };

            BenchmarkProcessor benchmarkProcessor = new BenchmarkProcessor();

            BenchmarkProcessorConfiguration benchmarkProcessorConfiguration = new BenchmarkProcessorConfiguration();

            IEnumerable<IBenchmarkComponentResult> benchmarkResults = benchmarkProcessor.Execute(benchmarkProcessorConfiguration, benchmarkComponents);

            string formattedResults = string.Join(Environment.NewLine + Environment.NewLine, benchmarkResults.Select(benchmarkComponentResult => string.Format("Benchmark Component: {0}{1}{2}", benchmarkComponentResult.Name, Environment.NewLine, FormatBenchmarkResults(benchmarkComponentResult.RootOperationResult, 0))));

            Console.WriteLine(formattedResults);

            Console.ReadLine();
        }

        private static string FormatBenchmarkResults(IOperationResultBase benchmarkResult, int nestingLevel)
        {
            string formattedResults = nestingLevel == 0 ? "" : new string('-', nestingLevel * 3) + '→' + ' ';
            formattedResults += string.Format("{0}: {1}", benchmarkResult.Name.PadRight(22), benchmarkResult.Durations.Min.TotalMilliseconds.ToString("0.000 ms.").PadLeft(12));

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