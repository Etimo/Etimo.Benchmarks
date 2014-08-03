using Etimo.Benchmarks.Interfaces.Results;

namespace Etimo.Benchmarks.Implementations.Results
{
    internal class BenchmarkComponentResult : IBenchmarkComponentResult
    {
        public string Name { get; set; }
        public IOperationResultBase RootOperationResult { get; set; }
    }
}