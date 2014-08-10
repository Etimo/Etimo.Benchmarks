namespace Etimo.Benchmarks.Processors
{
    public class BenchmarkProcessorConfiguration
    {
        public int WarmupIterationCount { get; set; }
        public int BenchmarkIterationCount { get; set; }
        public bool GarbageCollectBeforeEachOperation { get; set; }
        public bool IfDebuggerIsAttachedThenThrowException { get; set; }
        public bool IfJitOptimizerDisabledThenThrowException { get; set; }

        public BenchmarkProcessorConfiguration()
        {
            WarmupIterationCount = 5;
            BenchmarkIterationCount = 10;
            GarbageCollectBeforeEachOperation = true;
            IfDebuggerIsAttachedThenThrowException = true;
            IfJitOptimizerDisabledThenThrowException = true;
        }
    }
}