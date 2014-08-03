using Etimo.Benchmarks.Interfaces.Results;

namespace Etimo.Benchmarks.Implementations.Results
{
    internal class SingleIterationOperationWithFuncResult : SingleIterationOperationResultBase, ISingleIterationOperationWithFuncResult
    {
        public object FuncReturnValue { get; set; }
    }
}