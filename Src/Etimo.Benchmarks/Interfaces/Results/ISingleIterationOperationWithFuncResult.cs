namespace Etimo.Benchmarks.Interfaces.Results
{
    internal interface ISingleIterationOperationWithFuncResult : ISingleIterationOperationResultBase
    {
        object FuncReturnValue { get; }
    }
}