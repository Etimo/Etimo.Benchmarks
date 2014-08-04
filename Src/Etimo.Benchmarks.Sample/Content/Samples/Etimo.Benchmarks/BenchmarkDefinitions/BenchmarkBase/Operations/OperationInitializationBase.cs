using System;
using Etimo.Benchmarks.Interfaces.Operations;

namespace Samples.Etimo.Benchmarks.BenchmarkDefinitions.BenchmarkBase.Operations
{
    public class OperationInitializationBase : IOperationWithAction
    {
        public string Name { get { return "Initialization"; } }
        public Action Delegate { get; set; }
    }
}