namespace CodeBase.View
{
    public class ViewControl
    {
        private MovingNodes _movingNodes;
        private SelectingNodes _selectingNodes;
        
        private readonly Workspace _workspace;
        private readonly IInputEventsView _inputEvents;
        
        public ViewControl(Workspace workspace, IInputEventsView inputEvents)
        {
            _workspace = workspace;
            _inputEvents = inputEvents;
        }

        public void Initialize()
        {
            _selectingNodes = new SelectingNodes(_workspace, _inputEvents);
            _movingNodes = new MovingNodes(_selectingNodes, _inputEvents);
           
            _selectingNodes.Initialize();
            _movingNodes.Initialize();
        }
    }
}