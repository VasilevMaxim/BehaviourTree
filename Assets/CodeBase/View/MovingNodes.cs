using System;
using UnityEngine;

namespace CodeBase.View
{
    public class MovingNodes : IDisposable
    {
        private readonly SelectingNodes _selectingNodes;
        private readonly IInputEventsView _inputEventsView;
        private Vector2 _mousePositionMouseDown;
        private Vector2 _nodePositionMouseDown;
        private readonly WorkspaceWindow _window;
        private Workspace _workspace;

        public MovingNodes(SelectingNodes selectingNodes, Workspace workspace, WorkspaceWindow window, IInputEventsView inputEvents)
        {
            _workspace = workspace;
            _window = window;
            _selectingNodes = selectingNodes;
            _inputEventsView = inputEvents;
        }
        
        public void Initialize()
        {
            _inputEventsView.MouseDown += InputEventsOnMouseDown;
            _inputEventsView.MouseDrag += InputEventsOnMouseDrag;
        }

        private void InputEventsOnMouseDown(Vector2 mousePosition)
        {
            if (_selectingNodes.NodeViewSelected == null)
            {
                return;
            }
            
            _mousePositionMouseDown = mousePosition;
            _nodePositionMouseDown = _selectingNodes.NodeViewSelected.Rect.position;
        }

        public void Dispose()
        {
            _inputEventsView.MouseDrag -= InputEventsOnMouseDrag;
        }
        
        private void InputEventsOnMouseDrag(Vector2 mousePosition)
        {
            if (_selectingNodes.NodeViewSelected == null)
            {
                return;
            }

            Move(_selectingNodes.NodeViewSelected, mousePosition);
        }
        
        private void Move(INodeView nodeView, Vector2 mousePosition)
        {
            var blocked = mousePosition - (_mousePositionMouseDown - _nodePositionMouseDown);
            nodeView.Rect = nodeView.Rect.GetRectNewPosition(blocked);
            
            Clips(nodeView);
            ControlSizeScrollWindow(nodeView);
        }

        private void Clips(INodeView nodeView)
        {
            foreach (var node in _workspace.Nodes)
            {
                if (node == nodeView)
                {
                    continue;
                }

                nodeView.Rect = nodeView.Rect.Clip(node.Rect, 20);
            }
        }
        
        private void ControlSizeScrollWindow(INodeView nodeView)
        {
            if (nodeView.Rect.xMax > _window.RectScale.xMax)
            {
                _window.RectScale = new Rect(_window.RectScale.x, _window.RectScale.y, _window.RectScale.width + (nodeView.Rect.xMax - _window.RectScale.xMax), _window.RectScale.height);
            } 
            
            if (nodeView.Rect.position.x < _window.RectScale.xMin)
            {
                _window.RectScale = new Rect(nodeView.Rect.position.x, _window.RectScale.y, _window.RectScale.width + (_window.RectScale.xMin - nodeView.Rect.position.x), _window.RectScale.height);
            }
            
            if (nodeView.Rect.yMax > _window.RectScale.yMax) 
            {
                _window.RectScale = new Rect(_window.RectScale.x, _window.RectScale.y, _window.RectScale.width, _window.RectScale.height  + (nodeView.Rect.yMax - _window.RectScale.yMax));
            }
            
            if (nodeView.Rect.position.y < _window.RectScale.yMin)
            {
                _window.RectScale = new Rect(_window.RectScale.x, nodeView.Rect.position.y, _window.RectScale.width, _window.RectScale.height + (_window.RectScale.yMin - nodeView.Rect.position.y));
            }
        }
    }
}