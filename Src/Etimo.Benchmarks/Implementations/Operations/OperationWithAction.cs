using System;
using Etimo.Benchmarks.Interfaces.Operations;

namespace Etimo.Benchmarks.Implementations.Operations
{
    public class OperationWithAction : OperationBase, IOperationWithAction
    {
        public Action Delegate { get; set; }
    }
}