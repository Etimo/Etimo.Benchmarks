using System.Collections.Generic;
using Etimo.Benchmarks.Interfaces.Results;

namespace Etimo.Benchmarks.Implementations.Results
{
    internal class OperationGroupResult : OperationResultBase, IOperationGroupResult
    {
        public IEnumerable<IOperationResultBase> ChildOperationResults { get; set; }
    }
}