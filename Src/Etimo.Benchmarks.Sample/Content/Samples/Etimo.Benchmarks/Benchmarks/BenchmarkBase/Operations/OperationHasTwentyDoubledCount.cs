using System;
using Etimo.Benchmarks.Interfaces.Operations;

namespace Etimo.Benchmarks.Sample.Content.Benchmarks.BenchmarkBase.Operations
{
    public class OperationHasTwentyDoubledCount : IOperationWithFunc<int>
    {
        public string Name { get { return "HasTwentyDoubledCount"; } }
        public Func<int> Delegate { get; set; }
    }
}