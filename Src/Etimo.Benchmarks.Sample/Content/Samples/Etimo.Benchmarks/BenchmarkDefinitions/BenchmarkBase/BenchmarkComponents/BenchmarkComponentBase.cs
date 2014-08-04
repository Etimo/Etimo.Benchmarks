using Etimo.Benchmarks.Interfaces.Components;
using Samples.Etimo.Benchmarks.BenchmarkDefinitions.BenchmarkBase.Operations;

namespace Samples.Etimo.Benchmarks.BenchmarkDefinitions.BenchmarkBase.BenchmarkComponents
{
    public abstract class BenchmarkComponentBase : IBenchmarkComponent<CollectionBenchmarkRootOperation>
    {
        public abstract string Name { get; }
        public CollectionBenchmarkRootOperation RootOperation { get; set; }
    }
}<