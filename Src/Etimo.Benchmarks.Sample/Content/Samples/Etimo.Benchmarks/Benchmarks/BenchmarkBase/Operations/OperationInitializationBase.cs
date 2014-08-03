using System;
using Etimo.Benchmarks.Interfaces.Operations;

namespace Etimo.Benchmarks.Sample.Content.Benchmarks.BenchmarkBase.Operations
{
    public class OperationInitializationBase : IOperationWithAction
    {
        public string Name { get { return "Initialization"; } }
        public Action Delegate { get; set; }
    }
}