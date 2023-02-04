namespace CodeBase.View
{
    public class ViewContainer
    {
        private readonly InspectorWindow _inspector;
        
        private StatusBar _statusBar;
        
        private readonly ContextMenu _contextMenu;
        private readonly MenuBar _menuBar;
        private readonly HintPositionView _hintPositionView;
        private WorkspaceWindow _workspaceWindow;

        public ViewContainer(IInputEventsView inputEvents, IGetterNodesView getterNodesView, MenuBar menuBar, WorkspaceWindow workspaceWindow)
        {
            _workspaceWindow = workspaceWindow;
            _inspector = new InspectorWindow();
            _contextMenu = new ContextMenu(_workspaceWindow, inputEvents);
            _statusBar = new StatusBar(_workspaceWindow);

            _menuBar = menuBar;
        }

        public void Draw()
        {
            // Menu
            _menuBar.Update();

            // Windows
            _workspaceWindow.Update();
            _inspector.Update();
            _statusBar.Update();
        }
    }
}