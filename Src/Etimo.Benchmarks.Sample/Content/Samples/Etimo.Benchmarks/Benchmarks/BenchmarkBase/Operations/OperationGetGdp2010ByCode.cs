using System;
using Etimo.Benchmarks.Interfaces.Operations;

namespace Etimo.Benchmarks.Sample.Content.Benchmarks.BenchmarkBase.Operations
{
    public class OperationGetGdp2010ByCode : IOperationWithFunc<decimal>
    {
        public string Name { get { return "GetGdp2010ByCode"; } }
        public Func<decimal> Delegate { get; set; }
    }
}