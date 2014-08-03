namespace Etimo.Benchmarks.Interfaces.Results
{
    public interface IBenchmarkComponentResult
    {
        string Name { get; }
        IOperationResultBase RootOperationResult { get; }
    }
}