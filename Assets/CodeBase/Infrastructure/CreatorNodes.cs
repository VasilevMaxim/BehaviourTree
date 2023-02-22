using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<UIElement> UIElements => _uiElementsView;
        
        private SequenceView _firstSv;
        private SequenceView _firstSv2;
        private SequenceView _firstSv3;
        private RootView _rootView;

        private Root _rootModel;
        
        private readonly ContainerViewModel _containerViewModel;
        private readonly InputEvents _inputEvents;
        private readonly WorkspaceWindow _workspaceWindow;
        private readonly ContextMenu _contextMenu;
        
        private readonly NodeStyle _style;
        private readonly BlackboardStyle _blackboardStyle;
        
        private readonly List<UIElement> _uiElementsView;

        public CreatorNodes(ContainerViewModel containerViewModel, InputEvents inputEvents)
        {
            _containerViewModel = containerViewModel;
            _inputEvents = inputEvents;
            _style = Resources.Load<NodeStyle>("StyleSequence");
            _blackboardStyle = Resources.Load<BlackboardStyle>("BlackboardStyle");
            _uiElementsView = new List<UIElement>();

            _workspaceWindow = new WorkspaceWindow(_inputEvents, this);
            _contextMenu = new ContextMenu(_workspaceWindow, _inputEvents); 
            ContextMenuPresenter presenter = new ContextMenuPresenter(this, _contextMenu);
            
            inputEvents.KeyDown += InputEventsOnKeyDown;
        }

        private void InputEventsOnKeyDown(KeyCode keyCode)
        {
            if (keyCode == KeyCode.Delete)
            {
                Remove(_workspaceWindow.ViewControl.SelectingNodes.UIElementSelected);
            }
        }

        public void Create()
        {
            _rootView = new RootView(_style, new WaypointsDrawer(3), new Vector2(0, 100));
            _rootModel = new Root();
            _containerViewModel.Add(_rootModel, _rootView);
            _uiElementsView.Add(_rootView);
        }

        public void Remove(UIElement element)
        {
            _uiElementsView.Remove(element);
        }

        public void AddSequence(bool isMousePosition)
        {
            var sequenceView = new SequenceView(_style, new WaypointsDrawer(4), isMousePosition ? _inputEvents.MousePosition : _workspaceWindow.Rect.center);
            var sequence = new Sequence();
            var sequencePresenter = new SequencePresenter(sequence, sequenceView, _containerViewModel);

            foreach (var nodeClip in _uiElementsView)
            {
                sequenceView.Rect = sequenceView.Rect.Clip(nodeClip.Rect, 20);
                nodeClip.Rect = nodeClip.Rect.Clip(sequenceView.Rect, 20);
            }
            
            _containerViewModel.Add(sequence, sequenceView);
            _uiElementsView.Add(sequenceView);
        }
        
        public void AddSelector(bool isMousePosition)
        {
            var selectorView = new SelectorView(_style, new WaypointsDrawer(4), isMousePosition ? _inputEvents.MousePosition : _workspaceWindow.Rect.center);
            var selector = new Selector();
            var selectorPresenter = new SelectorPresenter(selector, selectorView, _containerViewModel);

            foreach (var nodeClip in _uiElementsView)
            {
                selectorView.Rect = selectorView.Rect.Clip(nodeClip.Rect, 20);
                nodeClip.Rect = nodeClip.Rect.Clip(selectorView.Rect, 20);
            }
            
            _containerViewModel.Add(selector, selectorView);
            _uiElementsView.Add(selectorView);
        }

        public void AddSimpleParallel(bool isMousePosition)
        {
            throw new NotImplementedException();
        }

        public void AddComment(bool isMousePosition)
        {
            var commentView = new CommentView(_style, isMousePosition ? _inputEvents.MousePosition : _workspaceWindow.Rect.center);
            foreach (var nodeClip in _uiElementsView)
            {
                commentView.Rect = commentView.Rect.Clip(nodeClip.Rect, 20);
                nodeClip.Rect = nodeClip.Rect.Clip(commentView.Rect, 20);
            }
            
            _uiElementsView.Add(commentView);
        }

        public void AddBlackboard()
        {
            var selectorView = new BlackboardView(_blackboardStyle, _workspaceWindow.Rect.center);
            _uiElementsView.Insert(0, selectorView);
        }

        public void AddTask(Type typeNodeView)
        {
            var sequence = new Sequence();
            var taskView = CreateNodeInstance(typeNodeView);
            
            _containerViewModel.Add(sequence, taskView);
            _uiElementsView.Add(taskView);
        }

        public IEnumerable<INodeView> GetNodes()
        {
            return _uiElementsView.OfType<INodeView>();
        }

        private INodeView CreateNodeInstance(Type type)
        {
            return (INodeView) Activator.CreateInstance(type, 
                                                        Resources.Load<NodeStyle>("StyleSequence"), 
                                                        new WaypointsDrawer(4), 
                                                        (Vector3) _inputEvents.MousePosition);
        }
    }
}