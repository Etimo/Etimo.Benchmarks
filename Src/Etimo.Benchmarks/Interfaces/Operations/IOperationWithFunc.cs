using System;

namespace Etimo.Benchmarks.Interfaces.Operations
{
    public interface IOperationWithFunc<out T> : IOperationBase
    {
        Func<T> Delegate { get; }
    }
}