using Etimo.Benchmarks.Interfaces.Operations;

namespace Samples.Etimo.Benchmarks.BenchmarkDefinitions.BenchmarkBase.Operations
{
    public class CollectionBenchmarkRootOperation : IOperationGroup<OperationInitializationBase, OperationGetGdp2010ByCode, OperationGetGdp2010ByName, OperationGroupByIncrease>
    {
        public string Name { get { return "Benchmark Root"; } }
        public OperationInitializationBase Operation1 { get; set; }
        public OperationGetGdp2010ByCode Operation2 { get; set; }
        public OperationGetGdp2010ByName Operation3 { get; set; }
        public OperationGroupByIncrease Operation4 { get; set; }
    }
}