namespace CodeBase.View
{
    public class ViewControl
    {
        private MovingNodes _movingNodes;
        private SelectingNodes _selectingNodes;
        
        private readonly Workspace _workspace;
        private readonly WorkspaceWindow _window;
        private readonly IInputEventsView _inputEvents;
        
        public ViewControl(Workspace workspace, WorkspaceWindow window, IInputEventsView inputEvents)
        {
            _workspace = workspace;
            _window = window;
            _inputEvents = inputEvents;
        }

        public void Initialize()
        {
            _selectingNodes = new SelectingNodes(_workspace, _inputEvents);
            _movingNodes = new MovingNodes(_selectingNodes, _window, _inputEvents);
           
            _selectingNodes.Initialize();
            _movingNodes.Initialize();
        }
    }
}