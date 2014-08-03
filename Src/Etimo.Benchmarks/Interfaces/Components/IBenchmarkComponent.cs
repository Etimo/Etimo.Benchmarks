using Etimo.Benchmarks.Interfaces.Operations;

namespace Etimo.Benchmarks.Interfaces.Components
{
    public interface IBenchmarkComponent<out TRootOperation>
        where TRootOperation : IOperationBase
    {
        string Name { get; }
        TRootOperation RootOperation { get; }
    }
}