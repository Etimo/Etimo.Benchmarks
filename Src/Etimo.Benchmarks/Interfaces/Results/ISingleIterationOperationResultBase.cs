using System;

namespace Etimo.Benchmarks.Interfaces.Results
{
    internal interface ISingleIterationOperationResultBase
    {
        string Name { get; }
        TimeSpan Duration { get; }
    }
}