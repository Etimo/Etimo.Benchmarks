using System.Collections.Generic;

namespace Etimo.Benchmarks.Interfaces.Results
{
    public interface IOperationGroupResult : IOperationResultBase
    {
        IEnumerable<IOperationResultBase> ChildOperationResults { get; }
    }
}