using System.Collections.Generic;
using CodeBase.Model;
using CodeBase.Presenter;
using CodeBase.View;

namespace CodeBase.Infrastructure
{
    internal class ContainerViewModel : IContainerModelView, IMatchingAddable
    {
        private readonly Dictionary<INodeView, Node> _matches;

        public ContainerViewModel()
        {
            _matches = new Dictionary<INodeView, Node>();
        }

        public Node GetModelByView(INodeView nodeViewView)
        {
            return _matches[nodeViewView];
        }

        public void Add(Node nodeModel, INodeView nodeViewView)
        {
            _matches.Add(nodeViewView, nodeModel);
        }
    }
}