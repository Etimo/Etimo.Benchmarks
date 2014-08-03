namespace Etimo.Benchmarks.Interfaces.Operations
{
    public interface IOperationGroup<out TOperation1> : IOperationGroupBase
        where TOperation1 : IOperationBase
    {
        TOperation1 Operation1 { get; }
    }

    public interface IOperationGroup<out TOperation1, out TOperation2> : IOperationGroupBase
        where TOperation1 : IOperationBase
        where TOperation2 : IOperationBase
    {
        TOperation1 Operation1 { get; }
        TOperation2 Operation2 { get; }
    }

    public interface IOperationGroup<out TOperation1, out TOperation2, out TOperation3> : IOperationGroupBase
        where TOperation1 : IOperationBase
        where TOperation2 : IOperationBase
        where TOperation3 : IOperationBase
    {
        TOperation1 Operation1 { get; }
        TOperation2 Operation2 { get; }
        TOperation3 Operation3 { get; }
    }

    public interface IOperationGroup<out TOperation1, out TOperation2, out TOperation3, out TOperation4> : IOperationGroupBase
        where TOperation1 : IOperationBase
        where TOperation2 : IOperationBase
        where TOperation3 : IOperationBase
        where TOperation4 : IOperationBase
    {
        TOperation1 Operation1 { get; }
        TOperation2 Operation2 { get; }
        TOperation3 Operation3 { get; }
        TOperation4 Operation4 { get; }
    }

    public interface IOperationGroup<out TOperation1, out TOperation2, out TOperation3, out TOperation4, out TOperation5> : IOperationGroupBase
        where TOperation1 : IOperationBase
        where TOperation2 : IOperationBase
        where TOperation3 : IOperationBase
        where TOperation4 : IOperationBase
        where TOperation5 : IOperationBase
    {
        TOperation1 Operation1 { get; }
        TOperation2 Operation2 { get; }
        TOperation3 Operation3 { get; }
        TOperation4 Operation4 { get; }
        TOperation5 Operation5 { get; }
    }
}