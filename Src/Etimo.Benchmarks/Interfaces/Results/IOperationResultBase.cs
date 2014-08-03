namespace Etimo.Benchmarks.Interfaces.Results
{
    public interface IOperationResultBase
    {
        string Name { get; }
        IDurations Durations { get; }
    }
}