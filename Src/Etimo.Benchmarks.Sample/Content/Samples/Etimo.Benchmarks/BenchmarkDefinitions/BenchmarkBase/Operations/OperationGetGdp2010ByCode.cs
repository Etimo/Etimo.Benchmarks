using System;
using Etimo.Benchmarks.Interfaces.Operations;

namespace Samples.Etimo.Benchmarks.BenchmarkDefinitions.BenchmarkBase.Operations
{
    public class OperationGetGdp2010ByCode : IOperationWithFunc<decimal>
    {
        public string Name { get { return "GetGdp2010ByCode"; } }
        public Func<decimal> Delegate { get; set; }
    }
}