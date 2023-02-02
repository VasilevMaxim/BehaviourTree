using CodeBase.Model;
using CodeBase.View;

namespace CodeBase.Presenter
{
    public class SequencePresenter
    {
        private readonly Sequence _sequence;
        private readonly SequenceView _view;
        private readonly IContainerModelView _container;

        public SequencePresenter(Sequence sequence,
                                 SequenceView view,
                                 IContainerModelView container)
        {
            _sequence = sequence;
            _view = view;
            _container = container;

            _view.AddedChild += ViewOnAddedChild;
            _view.SetedParent += ViewOnSetedParent;
        }

        private void ViewOnSetedParent(INodeView parent)
        {
            _sequence.SetParent(_container.GetModelByView(parent));
        }

        private void ViewOnAddedChild(INodeView child)
        {
            _sequence.AddChild(_container.GetModelByView(child));
        }


        public void Initialize()
        {
            
        }

    }
}