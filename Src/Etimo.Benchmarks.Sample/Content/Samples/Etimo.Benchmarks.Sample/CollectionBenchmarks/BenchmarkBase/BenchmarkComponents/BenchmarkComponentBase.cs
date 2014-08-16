using Etimo.Benchmarks.Interfaces.Components;
using Etimo.Benchmarks.Sample.CollectionBenchmarks.BenchmarkBase.OperationGroups;

namespace Etimo.Benchmarks.Sample.CollectionBenchmarks.BenchmarkBase.BenchmarkComponents
{
    public abstract class BenchmarkComponentBase : IBenchmarkComponent<CollectionBenchmarkRootOperationGroup>
    {
        public abstract string Name { get; }
        public CollectionBenchmarkRootOperationGroup RootOperation { get; set; }
    }
}