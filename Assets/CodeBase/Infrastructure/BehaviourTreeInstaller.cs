using System;
using CodeBase.Presenter;
using CodeBase.View;
using ContextMenu = CodeBase.View.ContextMenu;

namespace CodeBase.Infrastructure
{
    public class BehaviourTreeInstaller
    {
        private readonly InputEvents _inputEvents;
        private readonly MenuBar _menuBar;
        private readonly StatusBar _statusBar;
        private readonly InspectorWindow _inspector;
        private readonly WorkspaceWindow _workspaceWindow;

        public BehaviourTreeInstaller(Action repaint)
        {
            _inputEvents = new InputEvents(repaint);
            
            CreatorNodes creatorNodes = new CreatorNodes(new ContainerViewModel(), _inputEvents);
            creatorNodes.Create();

            var menuBar = new MenuBar();
            ToolbarPresenter toolbar = new ToolbarPresenter(menuBar, creatorNodes);

            _workspaceWindow = creatorNodes.WorkspaceWindow;
            _inspector = new InspectorWindow();
            _statusBar = new StatusBar(_workspaceWindow);

            _menuBar = menuBar;
        }
        public void Update()
        {
            CheckInput();
            Draw();
        }
        
        private void Draw()
        {
            // Menu
            _menuBar.Update();

            // Windows
            _workspaceWindow.Update();
            _inspector.Update();
            _statusBar.Update();
        }
        
        private void CheckInput()
        {
            _inputEvents.Check();
        }
    }
}