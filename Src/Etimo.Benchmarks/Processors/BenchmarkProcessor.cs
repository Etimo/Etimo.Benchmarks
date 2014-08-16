using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Etimo.Benchmarks.Implementations.Results;
using Etimo.Benchmarks.Interfaces.Components;
using Etimo.Benchmarks.Interfaces.Operations;
using Etimo.Benchmarks.Interfaces.Results;

namespace Etimo.Benchmarks.Processors
{
    public class BenchmarkProcessor
    {
        private ISingleIterationOperationWithActionResult ExecuteInner_OperationWithAction(IOperationWithAction operation)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            operation.Delegate();

            stopwatch.Stop();

            return new SingleIterationOperationWithActionResult()
            {
                Name = operation.Name,
                Duration = stopwatch.Elapsed,
            };
        }

        private ISingleIterationOperationWithFuncResult ExecuteInner_OperationWithFunc<T>(IOperationWithFunc<T> operation)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            T funcReturnValue = operation.Delegate();

            stopwatch.Stop();

            return new SingleIterationOperationWithFuncResult()
            {
                Name = operation.Name,
                Duration = stopwatch.Elapsed,
                FuncReturnValue = funcReturnValue,
            };
        }

        private bool IsJitOptimizerDisabled(Assembly assembly)
        {
            return assembly.GetCustomAttributes(typeof (DebuggableAttribute), false)
                .Select(customAttribute => (DebuggableAttribute) customAttribute)
                .Any(attribute => attribute.IsJITOptimizerDisabled);
        }

        private void EnsureAssembliesAreAllowed(BenchmarkProcessorConfiguration benchmarkProcessorConfiguration, IEnumerable<Assembly> assemblies)
        {
            Assembly[] assembliesViolatingRuleJitOptimization = !benchmarkProcessorConfiguration.IfJitOptimizerIsDisabledThenThrowException ? new Assembly[] { } : assemblies.Where(IsJitOptimizerDisabled).ToArray();

            if (assembliesViolatingRuleJitOptimization.Any())
                throw new Exception("To allow benchmarks to be executed when jit optimization is disabled, set BenchmarkProcessorConfiguration.IfJitOptimizerIsDisabledThenThrowException to false. The following assemblies have jit optimization disabled:" + string.Join("", assembliesViolatingRuleJitOptimization.Select(assembly => Environment.NewLine + assembly)));
        }

        public IEnumerable<IBenchmarkComponentResult> Execute<T>(BenchmarkProcessorConfiguration benchmarkProcessorConfiguration, params Func<T>[] benchmarkComponents)
            where T : IBenchmarkComponent<IOperationBase>
        {
            if (benchmarkProcessorConfiguration.IfJitOptimizerIsDisabledThenThrowException)
            {
                AppDomain.CurrentDomain.AssemblyLoad += (sender, args) => EnsureAssembliesAreAllowed(benchmarkProcessorConfiguration, new [] {args.LoadedAssembly});

                EnsureAssembliesAreAllowed(benchmarkProcessorConfiguration, AppDomain.CurrentDomain.GetAssemblies());
            }


            for (int iterationIndex = 0; iterationIndex < benchmarkProcessorConfiguration.WarmupIterationCount; iterationIndex++)
                foreach (Func<T> benchmarkFactory in benchmarkComponents)
                    BenchmarkAndExecuteInner(benchmarkProcessorConfiguration, benchmarkFactory().RootOperation);

            List<Tuple<string, List<ISingleIterationOperationResultBase>>> benchmarkComponentsSingleIterationsBenchmarkProcessorResults = new List<Tuple<string, List<ISingleIterationOperationResultBase>>>(benchmarkComponents.Select(benchmarkComponentFactory => new Tuple<string, List<ISingleIterationOperationResultBase>>(benchmarkComponentFactory().Name, new List<ISingleIterationOperationResultBase>())));

            for (int iterationIndex = 0; iterationIndex < benchmarkProcessorConfiguration.BenchmarkIterationCount; iterationIndex++)
                for (int benchmarkIndex = 0; benchmarkIndex < benchmarkComponents.Length; benchmarkIndex++)
                    benchmarkComponentsSingleIterationsBenchmarkProcessorResults[benchmarkIndex].Item2.Add(BenchmarkAndExecuteInner(benchmarkProcessorConfiguration, benchmarkComponents[benchmarkIndex]().RootOperation));

            return benchmarkComponentsSingleIterationsBenchmarkProcessorResults.Select(tuple => new BenchmarkComponentResult()
            {
                Name = tuple.Item1,
                RootOperationResult = CalculateAggregateResultBasedOnMultipleIterations(tuple.Item2),
            });
        }

        private IOperationResultBase CalculateAggregateResultBasedOnMultipleIterations(IEnumerable<ISingleIterationOperationResultBase> arg)
        {
            ISingleIterationOperationResultBase firstIterationResult = arg.First();

            if (firstIterationResult is ISingleIterationOperationGroupResult)
                return CalculateAggregateResultBasedOnMultipleIterations_OperationGroup(arg.Cast<ISingleIterationOperationGroupResult>());

            if (firstIterationResult is ISingleIterationOperationWithActionResult)
                return CalculateAggregateResultBasedOnMultipleIterations_OperationWithAction(arg.Cast<ISingleIterationOperationWithActionResult>());

            if (firstIterationResult is ISingleIterationOperationWithFuncResult)
                return CalculateAggregateResultBasedOnMultipleIterations_OperationWithFunc(arg.Cast<ISingleIterationOperationWithFuncResult>());

            throw new Exception(string.Format("Logical error. Object of type {0} is not expected.", firstIterationResult.GetType()));
        }

        private IOperationGroupResult CalculateAggregateResultBasedOnMultipleIterations_OperationGroup(IEnumerable<ISingleIterationOperationGroupResult> iterations)
        {
            ISingleIterationOperationGroupResult firstIterationResult = iterations.First();

            return new OperationGroupResult()
            {
                Name = firstIterationResult.Name,
                Durations = CalculateDurations(iterations.Select(singleIterationOperationGroupResult => singleIterationOperationGroupResult.Duration)),
                ChildOperationResults = Enumerable.Range(0, firstIterationResult.ChildOperationResults.Count)
                    .Select(childOperationResultIndex => iterations.Select(result => result.ChildOperationResults[childOperationResultIndex]))
                    .Select(CalculateAggregateResultBasedOnMultipleIterations),
            };
        }

        private IOperationWithActionResult CalculateAggregateResultBasedOnMultipleIterations_OperationWithAction(IEnumerable<ISingleIterationOperationWithActionResult> iterations)
        {
            ISingleIterationOperationWithActionResult firstIterationResult = iterations.First();

            return new OperationWithActionResult()
            {
                Name = firstIterationResult.Name,
                Durations = CalculateDurations(iterations.Select(singleIterationOperationGroupResult => singleIterationOperationGroupResult.Duration)),
            };
        }

        private IOperationWithFuncResult CalculateAggregateResultBasedOnMultipleIterations_OperationWithFunc(IEnumerable<ISingleIterationOperationWithFuncResult> iterations)
        {
            ISingleIterationOperationWithFuncResult firstIterationResult = iterations.First();

            return new OperationWithFuncResult()
            {
                Name = firstIterationResult.Name,
                Durations = CalculateDurations(iterations.Select(singleIterationOperationGroupResult => singleIterationOperationGroupResult.Duration)),
                FuncReturnValue = firstIterationResult.FuncReturnValue,
            };
        }

        private IDurations CalculateDurations(IEnumerable<TimeSpan> iterationTimeSpans)
        {
            return new Durations()
            {
                Min = iterationTimeSpans.Min(),
                Max = iterationTimeSpans.Max(),
                Average = new TimeSpan((long)iterationTimeSpans.Select(ts => ts.Ticks).Average()),
            };
        }

        private ISingleIterationOperationResultBase BenchmarkAndExecuteInner<TOperation>(BenchmarkProcessorConfiguration benchmarkProcessorConfiguration, TOperation operation)
            where TOperation : IOperationBase
        {
            if (benchmarkProcessorConfiguration.GarbageCollectBeforeEachOperation)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }

            if (benchmarkProcessorConfiguration.IfDebuggerIsAttachedThenThrowException && System.Diagnostics.Debugger.IsAttached)
                throw new Exception("Debugger is attached. To allow benchmarks to be executed while the debugger is attached, set BenchmarkProcessorConfiguration.IfDebuggerIsAttachedThenThrowException to false.");

            if (operation is IOperationGroup<IOperationBase>)
            {
                var operationTyped = (IOperationGroup<IOperationBase>)operation;
                return BenchmarkAndExecuteInner_Group(benchmarkProcessorConfiguration, operationTyped, operationTyped.Operation1);
            }

            if (operation is IOperationGroup<IOperationBase, IOperationBase>)
            {
                var operationTyped = (IOperationGroup<IOperationBase, IOperationBase>)operation;
                return BenchmarkAndExecuteInner_Group(benchmarkProcessorConfiguration, operationTyped, operationTyped.Operation1, operationTyped.Operation2);
            }

            if (operation is IOperationGroup<IOperationBase, IOperationBase, IOperationBase>)
            {
                var operationTyped = (IOperationGroup<IOperationBase, IOperationBase, IOperationBase>)operation;
                return BenchmarkAndExecuteInner_Group(benchmarkProcessorConfiguration, operationTyped, operationTyped.Operation1, operationTyped.Operation2, operationTyped.Operation3);
            }

            if (operation is IOperationGroup<IOperationBase, IOperationBase, IOperationBase, IOperationBase>)
            {
                var operationTyped = (IOperationGroup<IOperationBase, IOperationBase, IOperationBase, IOperationBase>)operation;
                return BenchmarkAndExecuteInner_Group(benchmarkProcessorConfiguration, operationTyped, operationTyped.Operation1, operationTyped.Operation2, operationTyped.Operation3, operationTyped.Operation4);
            }

            if (operation is IOperationGroup<IOperationBase, IOperationBase, IOperationBase, IOperationBase, IOperationBase>)
            {
                var operationTyped = (IOperationGroup<IOperationBase, IOperationBase, IOperationBase, IOperationBase, IOperationBase>)operation;
                return BenchmarkAndExecuteInner_Group(benchmarkProcessorConfiguration, operationTyped, operationTyped.Operation1, operationTyped.Operation2, operationTyped.Operation3, operationTyped.Operation4, operationTyped.Operation5);
            }

            if (operation is IOperationWithAction)
            {
                IOperationWithAction operationTyped = (IOperationWithAction)operation;
                return ExecuteInner_OperationWithAction(operationTyped);
            }

            return ExecuteInner_OperationWithFunc((dynamic)operation);
        }

        private SingleIterationOperationGroupResult BenchmarkAndExecuteInner_Group(BenchmarkProcessorConfiguration benchmarkProcessorConfiguration, IOperationGroupBase operationGroup, params IOperationBase[] childOperations)
        {
            List<ISingleIterationOperationResultBase> childOperationResults = childOperations.Select(childOperation => BenchmarkAndExecuteInner(benchmarkProcessorConfiguration, childOperation)).ToList();

            return new SingleIterationOperationGroupResult()
            {
                Name = operationGroup.Name,
                Duration = new TimeSpan(childOperationResults.Select(childOperationResult => childOperationResult.Duration.Ticks).Sum()),
                ChildOperationResults = childOperationResults,
            };
        }
    }
}