namespace Etimo.Benchmarks.Interfaces.Results
{
    public interface IOperationWithFuncResult : IOperationResultBase
    {
        object FuncReturnValue { get; }
    }
}