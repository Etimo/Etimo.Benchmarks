using Etimo.Benchmarks.Interfaces.Results;

namespace Etimo.Benchmarks.Implementations.Results
{
    internal class OperationResultBase : IOperationResultBase
    {
        public string Name { get; set; }
        public IDurations Durations { get; set; }
    }
}