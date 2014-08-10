using Etimo.Benchmarks.Interfaces.Components;
using Samples.Etimo.Benchmarks.CollectionBenchmarks.BenchmarkBase.OperationGroups;

namespace Samples.Etimo.Benchmarks.CollectionBenchmarks.BenchmarkBase.BenchmarkComponents
{
    public abstract class BenchmarkComponentBase : IBenchmarkComponent<CollectionBenchmarkRootOperationGroup>
    {
        public abstract string Name { get; }
        public CollectionBenchmarkRootOperationGroup RootOperation { get; set; }
    }
}