namespace CodeBase.View
{
    public class ViewContainer
    {
        private readonly WorkspaceWindow _workspace;
        private readonly InspectorWindow _inspector;
        
        private readonly ContextMenu _contextMenu;
        private readonly MenuBar _menuBar;
        private StatusBar _statusBar;

        public ViewContainer(IInputEventsView inputEvents, IGetterNodesView getterNodesView, MenuBar menuBar)
        {
            _workspace = new WorkspaceWindow(inputEvents, getterNodesView);
            _inspector = new InspectorWindow();
            _contextMenu = new ContextMenu(_workspace, inputEvents);
            _statusBar = new StatusBar(_workspace);
            _menuBar = menuBar;
        }

        public void Draw()
        {
            // Menu
            _menuBar.Update();

            // Windows
            _workspace.Update();
            _inspector.Update();
            _statusBar.Update();
        }
    }
}