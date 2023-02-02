using CodeBase.Model;
using CodeBase.View;

namespace CodeBase.Infrastructure
{
    public interface IMatchingAddable
    {
        void Add(Node nodeModel, INodeView nodeViewView);
    }
}