using System.Collections.Generic;

namespace CodeBase.View
{
    public interface IGetterNodesView
    {
        IEnumerable<INodeView> GetNodes();
    }
    
    public class WorkspaceWindow : Window
    {
        private SequenceView _sv;
        private readonly SequenceView _sv2;
        private TaskView _task;

        
        private readonly DrawerLinks _drawerLinks;
        private readonly Workspace _workspace;
        private readonly InputDrawerLinks _inputDrawerLinks;
        private readonly ViewControl _viewControl;

        public WorkspaceWindow(IInputEventsView inputEvents, IGetterNodesView getterNodesView)
        {
            _workspace = new Workspace();
            _drawerLinks = new DrawerLinks(new PaverWayBezier(), new DrawerLink(1), new DrawerArrow());
            _inputDrawerLinks = new InputDrawerLinks(_workspace, _drawerLinks, inputEvents);
            _viewControl = new ViewControl(_workspace, inputEvents);
            _viewControl.Initialize();
            _workspace.AddElements(getterNodesView.GetNodes());

            // _sv = new SequenceView(new Vector2(100, 100));
            // _sv2 = new SequenceView(new Vector2(100, 200));
            // _task = new TaskView(new Vector2(100, 400));
            // _controlLinker = new ControlLinker(new []{_sv, _sv2, (IUpdatable) _task});
        }
    
        public void Update()
        {
            //GUI.Box(new Rect(0, 100, Screen.width * 0.8f, Screen.height - 100), GUIContent.none);
            _workspace.Nodes.ForEach(f => f.Update());
            _inputDrawerLinks.Draw();
            
            //_sv.Update();
            //_sv2.Update();
            //_task.Update();
          // _controlLinker.Update();
        }

        public void AddSequence()
        {
           // _sequences.Add(new SequenceView(new Vector2(0, 0)));
        }
        
        public void AddSelector()
        {
           // _sequences.Add(new SequenceView(new Vector2(0, 0)));
        }
    }
}