using CodeBase.View;

namespace CodeBase.Presenter
{
    public interface ICreatorNodes
    {
        void AddSequence();
        void AddTask(INodeView view);
    }
}