using System;
using Etimo.Benchmarks.Interfaces.Operations;

namespace Etimo.Benchmarks.Implementations.Operations
{
    public class OperationWithFunc<T> : OperationBase, IOperationWithFunc<T>
    {
        public Func<T> Delegate { get; set; }
    }
}