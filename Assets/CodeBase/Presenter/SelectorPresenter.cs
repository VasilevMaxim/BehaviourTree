using CodeBase.Model;
using CodeBase.View;

namespace CodeBase.Presenter
{
    public class SelectorPresenter
    {
        private readonly Selector _model;
        private readonly SelectorView _view;
        private readonly IContainerModelView _container;

        public SelectorPresenter(Selector model,
                                 SelectorView view,
                                 IContainerModelView container)
        {
            _model = model;
            _view = view;
            _container = container;

            _view.AddedChild += ViewOnAddedChild;
            _view.SetedParent += ViewOnSetedParent;
            _view.RemovedChild += ViewOnRemovedChild;
            _view.RemovedParent += ViewOnRemovedParent;
        }

        private void ViewOnSetedParent(INodeView parent)
        {
            _model.SetParent(_container.GetModelByView(parent));
        }

        private void ViewOnAddedChild(INodeView child)
        {
            _model.AddChild(_container.GetModelByView(child));
        }
        
        private void ViewOnRemovedParent()
        {
            _model.RemoveParent();
        }

        private void ViewOnRemovedChild(INodeView child)
        {
            _model.RemoveChild(_container.GetModelByView(child));
        }

        public void Initialize()
        {
            
        }

    }
}