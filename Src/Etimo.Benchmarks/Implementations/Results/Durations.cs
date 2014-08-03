using System;
using Etimo.Benchmarks.Interfaces.Results;

namespace Etimo.Benchmarks.Implementations.Results
{
    internal class Durations : IDurations
    {
        public TimeSpan Min { get; set; }
        public TimeSpan Average { get; set; }
        public TimeSpan Max { get; set; }
    }
}