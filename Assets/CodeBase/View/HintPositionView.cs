using UnityEngine;

namespace CodeBase.View
{
    public class HintPositionView
    {
        private readonly IInputEventsView _inputEventsView;

        public HintPositionView(IInputEventsView inputEventsView)
        {
            _inputEventsView = inputEventsView;
        }

        public void Draw(INodeView node, Vector2 delta)
        {
            if (node == null)
            {
                return;
            }
            
            var spaceY = 30;
            var positionX = node.Rect.position.x;
            var positionY = node.Rect.position.y + node.Rect.height / 2 + 10 + spaceY;
            
            GUI.Box(new Rect(positionX, positionY, node.Rect.width, 20), node.Rect.x + ", " + node.Rect.y);
        }
    }
}