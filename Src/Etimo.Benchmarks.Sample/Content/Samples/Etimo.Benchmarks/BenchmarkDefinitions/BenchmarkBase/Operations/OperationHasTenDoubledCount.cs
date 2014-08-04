using System;
using Etimo.Benchmarks.Interfaces.Operations;

namespace Samples.Etimo.Benchmarks.BenchmarkDefinitions.BenchmarkBase.Operations
{
    public class OperationHasTenDoubledCount : IOperationWithFunc<int>
    {
        public string Name { get { return "HasTenDoubledCount"; } }
        public Func<int> Delegate { get; set; }
    }
}