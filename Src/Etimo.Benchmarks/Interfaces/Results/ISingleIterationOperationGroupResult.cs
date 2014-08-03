using System.Collections.Generic;

namespace Etimo.Benchmarks.Interfaces.Results
{
    internal interface ISingleIterationOperationGroupResult : ISingleIterationOperationResultBase
    {
        IList<ISingleIterationOperationResultBase> ChildOperationResults { get; }
    }
}