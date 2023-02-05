using System.Collections.Generic;

namespace CodeBase.View
{
    public interface IGetterNodesView
    {
        IEnumerable<INodeView> GetNodes();
        IEnumerable<UIElement> UIElements { get; }
    }
}