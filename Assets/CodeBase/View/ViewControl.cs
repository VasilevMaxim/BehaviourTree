namespace CodeBase.View
{
    public class ViewControl
    {
        private MovingNodes _movingNodes;
        public SelectingNodes SelectingNodes { get; private set; }
        
        private readonly Workspace _workspace;
        private readonly WorkspaceWindow _window;
        private readonly IInputEventsView _inputEvents;
        private readonly HintPositionView _hintPositionView;

        public ViewControl(Workspace workspace, WorkspaceWindow window, IInputEventsView inputEvents)
        {
            _workspace = workspace;
            _window = window;
            _inputEvents = inputEvents;
        }

        public void Initialize()
        {
            SelectingNodes = new SelectingNodes(_workspace, _inputEvents);
            _movingNodes = new MovingNodes(SelectingNodes, _workspace, _window, _inputEvents);
           
            SelectingNodes.Initialize();
            _movingNodes.Initialize();
        }
    }
}