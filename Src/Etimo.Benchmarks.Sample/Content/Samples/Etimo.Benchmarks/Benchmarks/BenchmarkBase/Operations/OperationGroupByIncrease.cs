using Etimo.Benchmarks.Interfaces.Operations;

namespace Etimo.Benchmarks.Sample.Content.Benchmarks.BenchmarkBase.Operations
{
    public class OperationGroupByIncrease : IOperationGroup<OperationHasFiveDoubledCount, OperationHasTenDoubledCount, OperationHasTwentyDoubledCount>
    {
        public string Name { get { return "ByIncrease"; } }
        public OperationHasFiveDoubledCount Operation1 { get; set; }
        public OperationHasTenDoubledCount Operation2 { get; set; }
        public OperationHasTwentyDoubledCount Operation3 { get; set; }
    }
}