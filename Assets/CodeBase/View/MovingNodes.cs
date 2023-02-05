using System;
using System.Linq;
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
            if (_selectingNodes.UIElementSelected == null)
            {
                return;
            }
            
            _mousePositionMouseDown = mousePosition;
            _nodePositionMouseDown = _selectingNodes.UIElementSelected.Rect.position;
        }

        public void Dispose()
        {
            _inputEventsView.MouseDrag -= InputEventsOnMouseDrag;
        }
        
        private void InputEventsOnMouseDrag(Vector2 mousePosition)
        {
            if (_selectingNodes.UIElementSelected == null)
            {
                return;
            }

            Move(_selectingNodes.UIElementSelected, mousePosition);
        }
        
        private void Move(UIElement uiElement, Vector2 mousePosition)
        {
            var blocked = mousePosition - (_mousePositionMouseDown - _nodePositionMouseDown);
            uiElement.Rect = uiElement.Rect.GetRectNewPosition(blocked);

            if (uiElement is INodeView)
            {
                Clips(uiElement);
            }

            ControlSizeScrollWindow(uiElement);
        }

        private void Clips(UIElement uiElement)
        {
            foreach (var node in _workspace.UIElements.OfType<INodeView>())
            {
                if (node == uiElement)
                {
                    continue;
                }

                uiElement.Rect = uiElement.Rect.Clip(node.Rect, 20);
            }
        }
        
        private void ControlSizeScrollWindow(UIElement uiElement)
        {
            if (uiElement.Rect.xMax > _window.RectScale.xMax)
            {
                _window.RectScale = new Rect(_window.RectScale.x, _window.RectScale.y, _window.RectScale.width + (uiElement.Rect.xMax - _window.RectScale.xMax), _window.RectScale.height);
            } 
            
            if (uiElement.Rect.position.x < _window.RectScale.xMin)
            {
                _window.RectScale = new Rect(uiElement.Rect.position.x, _window.RectScale.y, _window.RectScale.width + (_window.RectScale.xMin - uiElement.Rect.position.x), _window.RectScale.height);
            }
            
            if (uiElement.Rect.yMax > _window.RectScale.yMax) 
            {
                _window.RectScale = new Rect(_window.RectScale.x, _window.RectScale.y, _window.RectScale.width, _window.RectScale.height  + (uiElement.Rect.yMax - _window.RectScale.yMax));
            }
            
            if (uiElement.Rect.position.y < _window.RectScale.yMin)
            {
                _window.RectScale = new Rect(_window.RectScale.x, uiElement.Rect.position.y, _window.RectScale.width, _window.RectScale.height + (_window.RectScale.yMin - uiElement.Rect.position.y));
            }
        }
    }
}