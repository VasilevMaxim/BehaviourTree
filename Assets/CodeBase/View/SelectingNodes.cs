using System;
using UnityEngine;

namespace CodeBase.View
{
    public class SelectingNodes : IDisposable
    {
        public INodeView NodeViewSelected { get; private set; }
        
        private readonly Workspace _workspace;
        private readonly IInputEventsView _inputEventsView;

        public SelectingNodes(Workspace workspace, IInputEventsView inputEventsView)
        {
            _workspace = workspace;
            _inputEventsView = inputEventsView;
        }

        public void Initialize()
        {
            _inputEventsView.MouseDown += InputEventsViewOnMouseDown;
        }
        
                
        public void Dispose()
        {
            _inputEventsView.MouseDrag -= InputEventsViewOnMouseDown;
        }
        
        private void InputEventsViewOnMouseDown(Vector2 mousePosition)
        {
            _workspace.Nodes.ForEach(node => node.Deselect());
            NodeViewSelected = null;
            
            foreach (var node in _workspace.Nodes)
            {
                if (mousePosition.x > node.Position.x 
                    && mousePosition.x < node.Position.x + node.Scale.x
                    && mousePosition.y > node.Position.y
                    && mousePosition.y < node.Position.y + node.Scale.y)
                {
                    node.Select();
                    NodeViewSelected = node;
                }
            }
        }
    }
}