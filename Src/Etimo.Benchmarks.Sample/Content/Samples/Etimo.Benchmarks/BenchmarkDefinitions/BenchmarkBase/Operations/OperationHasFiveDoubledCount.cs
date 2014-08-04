using System;
using Etimo.Benchmarks.Interfaces.Operations;

namespace Samples.Etimo.Benchmarks.BenchmarkDefinitions.BenchmarkBase.Operations
{
    public class OperationHasFiveDoubledCount : IOperationWithFunc<int>
    {
        public string Name { get { return "HasFiveDoubledCount"; } }
        public Func<int> Delegate { get; set; }
    }
}