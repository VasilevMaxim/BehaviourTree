namespace CodeBase.View
{
    public class ViewContainer
    {
        private readonly WorkspaceWindow _workspace;
        private readonly InspectorWindow _inspector;
        
        private readonly ContextMenu _contextMenu;
        private readonly MenuBar _menuBar;
        
        public ViewContainer(IInputEventsView inputEvents, IGetterNodesView getterNodesView)
        {
            _workspace = new WorkspaceWindow(inputEvents, getterNodesView);
            _inspector = new InspectorWindow();
            _contextMenu = new ContextMenu();
            _menuBar = new MenuBar();
        }

        public void Draw()
        {
            // Menu
            _menuBar.Update();
            _contextMenu.Update();
            
            // Windows
            _workspace.Update();
            _inspector.Update();
        }
    }
}