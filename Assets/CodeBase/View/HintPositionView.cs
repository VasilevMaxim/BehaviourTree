using UnityEngine;

namespace CodeBase.View
{
    public class HintPositionView
    {
        public void Draw(INodeView node)
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