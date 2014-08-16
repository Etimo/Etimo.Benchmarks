using System;
using Etimo.Benchmarks.Interfaces.Operations;

namespace Etimo.Benchmarks.Sample.CollectionBenchmarks.BenchmarkBase.Operations
{
    public class OperationInitialization : IOperationWithAction
    {
        public string Name { get { return "Initialization"; } }
        public Action Delegate { get; set; }
    }
}