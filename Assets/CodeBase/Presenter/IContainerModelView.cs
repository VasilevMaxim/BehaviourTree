using CodeBase.Model;
using CodeBase.View;

namespace CodeBase.Presenter
{
    public interface IContainerModelView
    {
        Node GetModelByView(INodeView nodeViewView);
    }
}