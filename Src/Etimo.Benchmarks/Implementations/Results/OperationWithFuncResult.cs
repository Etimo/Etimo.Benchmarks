using Etimo.Benchmarks.Interfaces.Results;

namespace Etimo.Benchmarks.Implementations.Results
{
    internal class OperationWithFuncResult : OperationResultBase, IOperationWithFuncResult
    {
        public object FuncReturnValue { get; set; }
    }
}