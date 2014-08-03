using System;
using Etimo.Benchmarks.Interfaces.Results;

namespace Etimo.Benchmarks.Implementations.Results
{
    internal class SingleIterationOperationResultBase : ISingleIterationOperationResultBase
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
    }
}