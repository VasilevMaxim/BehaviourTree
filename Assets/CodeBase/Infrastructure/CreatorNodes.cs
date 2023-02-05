using System;
using System.Collections.Generic;
using CodeBase.Model;
using CodeBase.Presenter;
using CodeBase.View;
using UnityEngine;
using ContextMenu = CodeBase.View.ContextMenu;

namespace CodeBase.Infrastructure
{
    internal class CreatorNodes : IGetterNodesView, ICreatorNodes
    {
        public WorkspaceWindow WorkspaceWindow => _workspaceWindow;
        public ContextMenu ContextMenu => _contextMenu;
        
        private SequenceView _firstSv;
        private SequenceView _firstSv2;
        private SequenceView _firstSv3;
        private RootView _rootView;
        
        private readonly NodeStyle _style;

        private List<INodeView> _nodesView;
        private Root _rootModel;
        
        private readonly ContainerViewModel _containerViewModel;
        private readonly InputEvents _inputEvents;
        private readonly WorkspaceWindow _workspaceWindow;
        private readonly ContextMenu _contextMenu;
        
        public CreatorNodes(ContainerViewModel containerViewModel, InputEvents inputEvents)
        {
            _containerViewModel = containerViewModel;
            _inputEvents = inputEvents;
            _style = Resources.Load<NodeStyle>("StyleSequence");
            _nodesView = new List<INodeView>();

            _workspaceWindow = new WorkspaceWindow(_inputEvents, this);
            _contextMenu = new ContextMenu(_workspaceWindow, _inputEvents); 
            ContextMenuPresenter presenter = new ContextMenuPresenter(this, _contextMenu);
        }

        public void Create()
        {
            _rootView = new RootView(_style, new WaypointsDrawer(3), new Vector2(0, 100));
            _rootModel = new Root();
            _containerViewModel.Add(_rootModel, _rootView);
            _nodesView.Add(_rootView);
        }

        public void AddSequence()
        {
            var sequenceView = new SequenceView(_style, new WaypointsDrawer(4), _workspaceWindow.Rect.center);
            var sequence = new Sequence();
            var sequencePresenter = new SequencePresenter(sequence, sequenceView, _containerViewModel);

            foreach (var nodeClip in _nodesView)
            {
                sequenceView.Rect = sequenceView.Rect.Clip(nodeClip.Rect, 20);
                nodeClip.Rect = nodeClip.Rect.Clip(sequenceView.Rect, 20);
            }
            
            _containerViewModel.Add(sequence, sequenceView);
            _nodesView.Add(sequenceView);
        }
        
        public void AddSelector()
        {
            var selectorView = new SelectorView(_style, new WaypointsDrawer(4), _workspaceWindow.Rect.center);
            var selector = new Selector();
            var selectorPresenter = new SelectorPresenter(selector, selectorView, _containerViewModel);

            foreach (var nodeClip in _nodesView)
            {
                selectorView.Rect = selectorView.Rect.Clip(nodeClip.Rect, 20);
                nodeClip.Rect = nodeClip.Rect.Clip(selectorView.Rect, 20);
            }
            
            _containerViewModel.Add(selector, selectorView);
            _nodesView.Add(selectorView);
        }
        
        public void AddTask(Type typeNodeView)
        {
            var sequence = new Sequence();
            var taskView = CreateNodeInstance(typeNodeView);
            
            _containerViewModel.Add(sequence, taskView);
            _nodesView.Add(taskView);
        }

        public IEnumerable<INodeView> GetNodes()
        {
            return _nodesView;
        }

        private INodeView CreateNodeInstance(Type type)
        {
            return (INodeView) Activator.CreateInstance(type, Resources.Load<NodeStyle>("StyleSequence"), new WaypointsDrawer(4), (Vector3) _inputEvents.MousePosition);
        }
    }
}