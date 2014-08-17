namespace Etimo.Benchmarks.Processors
{
    public class BenchmarkProcessorConfiguration
    {
        public int WarmupIterationCount { get; set; }
        public int BenchmarkIterationCount { get; set; }
        public bool GarbageCollectBeforeEachOperation { get; set; }
        public bool IfDebuggerIsAttachedThenThrowException { get; set; }
        public bool IfJitOptimizerIsDisabledThenThrowException { get; set; }

        public BenchmarkProcessorConfiguration()
        {
            WarmupIterationCount = 2;
            BenchmarkIterationCount = 10;
            GarbageCollectBeforeEachOperation = true;
            IfDebuggerIsAttachedThenThrowException = true;
            IfJitOptimizerIsDisabledThenThrowException = true;
        }
    }
}