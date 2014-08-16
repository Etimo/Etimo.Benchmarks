using System;
using Etimo.Benchmarks.Interfaces.Operations;

namespace Etimo.Benchmarks.Sample.CollectionBenchmarks.BenchmarkBase.Operations
{
    public class OperationHasTenDoubledCount : IOperationWithFunc<int>
    {
        public string Name { get { return "HasTenDoubledCount"; } }
        public Func<int> Delegate { get; set; }
    }
}