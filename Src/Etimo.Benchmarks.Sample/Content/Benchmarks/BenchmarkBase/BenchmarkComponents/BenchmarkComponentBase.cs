using Etimo.Benchmarks.Interfaces.Components;
using Etimo.Benchmarks.Sample.Content.Benchmarks.BenchmarkBase.Operations;

namespace Etimo.Benchmarks.Sample.Content.Benchmarks.BenchmarkBase.BenchmarkComponents
{
    public abstract class BenchmarkComponentBase : IBenchmarkComponent<CollectionBenchmarkRootOperation>
    {
        public abstract string Name { get; }
        public CollectionBenchmarkRootOperation RootOperation { get; set; }
    }
}