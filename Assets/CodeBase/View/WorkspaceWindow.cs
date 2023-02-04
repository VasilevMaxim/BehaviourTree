using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.View
{
    public interface IGetterNodesView
    {
        IEnumerable<INodeView> GetNodes();
    }
    
    public class WorkspaceWindow : Window
    {
        public Rect Rect { get; set; }
        
        private SequenceView _sv;
        private readonly SequenceView _sv2;
        private TaskView _task;

        
        private readonly DrawerLinks _drawerLinks;
        private readonly Workspace _workspace;
        private readonly InputDrawerLinks _inputDrawerLinks;
        private readonly ViewControl _viewControl;
        private readonly IInputEventsView _inputEvents;
        private IGetterNodesView _getterNodesView;
        private Vector2 _scrollPosition;
        public Rect RectScale { get; set; }

        public WorkspaceWindow(IInputEventsView inputEvents, IGetterNodesView getterNodesView)
        {
            _inputEvents = inputEvents;
            _getterNodesView = getterNodesView;
            _workspace = new Workspace();
            _drawerLinks = new DrawerLinks(new PaverWayBezier(), new DrawerLink(1), new DrawerArrow());
            _inputDrawerLinks = new InputDrawerLinks(_workspace, _drawerLinks, inputEvents);
            _viewControl = new ViewControl(_workspace, this, inputEvents);
            _viewControl.Initialize();
            RectScale = new Rect(0, 0, 800, 1500);
            // _sv = new SequenceView(new Vector2(100, 100));
            // _sv2 = new SequenceView(new Vector2(100, 200));
            // _task = new TaskView(new Vector2(100, 400));
            // _controlLinker = new ControlLinker(new []{_sv, _sv2, (IUpdatable) _task});
        }

        public void Update()
        {
            Rect = new Rect(0, 70, Screen.width * 0.8f, Screen.height - 100);
            _inputEvents.SetDeltaScrollWindow(Rect.position - RectScale.position - _scrollPosition);

            
            _scrollPosition = GUI.BeginScrollView(Rect, _scrollPosition, RectScale);
            _workspace.Nodes = _getterNodesView.GetNodes().ToList();
            _workspace.Nodes.ForEach(f => f.Update());
            _inputDrawerLinks.Draw();
            
            GUI.EndScrollView();
            
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