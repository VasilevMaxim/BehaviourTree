namespace BehaviourTree.Core
{
    public interface ICompositable : INode
    {
        void AddChild(INode node);
    }
}