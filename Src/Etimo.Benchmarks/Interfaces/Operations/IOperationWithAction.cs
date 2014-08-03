using System;

namespace Etimo.Benchmarks.Interfaces.Operations
{
    public interface IOperationWithAction : IOperationBase
    {
        Action Delegate { get; }
    }
}