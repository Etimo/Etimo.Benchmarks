using Etimo.Benchmarks.Interfaces.Operations;

namespace Etimo.Benchmarks.Implementations.Operations
{
    public abstract class OperationBase : IOperationBase
    {
        public string Name { get; set; }
    }
}