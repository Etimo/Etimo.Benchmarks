using System.Collections.Generic;
using Etimo.Benchmarks.Interfaces.Results;

namespace Etimo.Benchmarks.Implementations.Results
{
    internal class SingleIterationOperationGroupResult : SingleIterationOperationResultBase, ISingleIterationOperationGroupResult
    {
        public IList<ISingleIterationOperationResultBase> ChildOperationResults { get; set; }
    }
}