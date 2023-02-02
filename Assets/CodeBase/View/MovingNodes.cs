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
        
        public MovingNodes(SelectingNodes selectingNodes, IInputEventsView inputEvents)
        {
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
            _nodePositionMouseDown = _selectingNodes.NodeViewSelected.Position;
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
            nodeView.Position = mousePosition - (_mousePositionMouseDown - _nodePositionMouseDown);
        }
    }
}