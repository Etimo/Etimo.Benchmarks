using System;

namespace Etimo.Benchmarks.Interfaces.Results
{
    public interface IDurations
    {
        TimeSpan Min { get; }
        TimeSpan Average { get; }
        TimeSpan Max { get; }
    }
}