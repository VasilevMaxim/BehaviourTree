namespace BehaviourTree.Core
{
    public interface ITask : INode
    {
        Status Run();
    }
}