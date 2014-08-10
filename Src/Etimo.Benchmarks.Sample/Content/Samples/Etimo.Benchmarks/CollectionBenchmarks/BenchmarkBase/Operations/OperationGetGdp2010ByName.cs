using System;
using Etimo.Benchmarks.Interfaces.Operations;

namespace Samples.Etimo.Benchmarks.CollectionBenchmarks.BenchmarkBase.Operations
{
    public class OperationGetGdp2010ByName : IOperationWithFunc<decimal>
    {
        public string Name { get { return "GetGdp2010ByName"; } }
        public Func<decimal> Delegate { get; set; }
    }
}