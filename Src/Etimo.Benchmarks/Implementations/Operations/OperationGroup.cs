using Etimo.Benchmarks.Interfaces.Operations;

namespace Etimo.Benchmarks.Implementations.Operations
{
    public class OperationGroup<TOperation1> : OperationGroupBase, IOperationGroup<TOperation1> where TOperation1 : IOperationBase
    {
        public TOperation1 Operation1 { get; set; }
    }

    public class OperationGroup<TOperation1, TOperation2> : OperationGroupBase, IOperationGroup<TOperation1, TOperation2>
        where TOperation1 : IOperationBase
        where TOperation2 : IOperationBase
    {
        public TOperation1 Operation1 { get; set; }
        public TOperation2 Operation2 { get; set; }
    }

    public class OperationGroup<TOperation1, TOperation2, TOperation3> : OperationGroupBase, IOperationGroup<TOperation1, TOperation2, TOperation3>
        where TOperation1 : IOperationBase
        where TOperation2 : IOperationBase
        where TOperation3 : IOperationBase
    {
        public TOperation1 Operation1 { get; set; }
        public TOperation2 Operation2 { get; set; }
        public TOperation3 Operation3 { get; set; }
    }

    public class OperationGroup<TOperation1, TOperation2, TOperation3, TOperation4> : OperationGroupBase, IOperationGroup<TOperation1, TOperation2, TOperation3, TOperation4>
        where TOperation1 : IOperationBase
        where TOperation2 : IOperationBase
        where TOperation3 : IOperationBase
        where TOperation4 : IOperationBase
    {
        public TOperation1 Operation1 { get; set; }
        public TOperation2 Operation2 { get; set; }
        public TOperation3 Operation3 { get; set; }
        public TOperation4 Operation4 { get; set; }
    }

    public class OperationGroup<TOperation1, TOperation2, TOperation3, TOperation4, TOperation5> : OperationGroupBase, IOperationGroup<TOperation1, TOperation2, TOperation3, TOperation4, TOperation5>
        where TOperation1 : IOperationBase
        where TOperation2 : IOperationBase
        where TOperation3 : IOperationBase
        where TOperation4 : IOperationBase
        where TOperation5 : IOperationBase
    {
        public TOperation1 Operation1 { get; set; }
        public TOperation2 Operation2 { get; set; }
        public TOperation3 Operation3 { get; set; }
        public TOperation4 Operation4 { get; set; }
        public TOperation5 Operation5 { get; set; }
    }
}