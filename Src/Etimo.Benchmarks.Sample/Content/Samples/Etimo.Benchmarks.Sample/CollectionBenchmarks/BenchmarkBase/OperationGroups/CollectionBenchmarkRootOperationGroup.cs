using Etimo.Benchmarks.Interfaces.Operations;
using Etimo.Benchmarks.Sample.CollectionBenchmarks.BenchmarkBase.Operations;

namespace Etimo.Benchmarks.Sample.CollectionBenchmarks.BenchmarkBase.OperationGroups
{
    public class CollectionBenchmarkRootOperationGroup : IOperationGroup<OperationInitialization, OperationGetGdp2010ByCode, OperationGetGdp2010ByName, OperationGroupByIncrease>
    {
        public string Name { get { return "Benchmark Root"; } }
        public OperationInitialization Operation1 { get; set; }
        public OperationGetGdp2010ByCode Operation2 { get; set; }
        public OperationGetGdp2010ByName Operation3 { get; set; }
        public OperationGroupByIncrease Operation4 { get; set; }
    }
}