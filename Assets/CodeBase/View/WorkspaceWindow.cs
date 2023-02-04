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
        public Rect RectScale { get; set; }
        
        private SequenceView _sv;
        private readonly SequenceView _sv2;
        private TaskView _task;

                
        private IGetterNodesView _getterNodesView;
        private Vector2 _scrollPosition;

        private readonly DrawerLinks _drawerLinks;
        private readonly Workspace _workspace;
        private readonly InputDrawerLinks _inputDrawerLinks;
        private readonly ViewControl _viewControl;
        private readonly IInputEventsView _inputEvents;
        private readonly HintPositionView _hintPositionView;
        private readonly GridFull _gridFull;

        public WorkspaceWindow(IInputEventsView inputEvents, IGetterNodesView getterNodesView)
        {
            _inputEvents = inputEvents;
            _getterNodesView = getterNodesView;
            _workspace = new Workspace();
            _drawerLinks = new DrawerLinks(new PaverWayBezier(), new DrawerLink(1), new DrawerArrow());
            _inputDrawerLinks = new InputDrawerLinks(_workspace, _drawerLinks, inputEvents);
            _viewControl = new ViewControl(_workspace, this, inputEvents);
            _gridFull = new GridFull(2);
            _hintPositionView = new HintPositionView();
            
            _viewControl.Initialize();
            RectScale = new Rect(0, 0, 800, 1500);
        }

        public void Update()
        {
            Rect = new Rect(0, 70, Screen.width * 0.8f, Screen.height - 118);

            _inputEvents.SetDeltaScrollWindow(Rect.position - RectScale.position - _scrollPosition);

            _scrollPosition = GUI.BeginScrollView(Rect, _scrollPosition, RectScale);
            
            _gridFull.Draw(Rect, RectScale.position + _scrollPosition);
            
            _workspace.Nodes = _getterNodesView.GetNodes().ToList();
            _workspace.Nodes.ForEach(f => f.Update());
            _inputDrawerLinks.Draw();
            _hintPositionView.Draw(_viewControl.SelectingNodes.NodeViewSelected);

            GUI.EndScrollView();
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