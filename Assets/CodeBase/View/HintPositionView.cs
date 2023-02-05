using UnityEngine;

namespace CodeBase.View
{
    public class HintPositionView
    {
        public void Draw(ISelectable selectableElement)
        {
            if (selectableElement == null)
            {
                return;
            }
            
            var positionX = selectableElement.Rect.position.x;
            var positionY = selectableElement.Rect.yMax + 10;
            
            GUI.Box(new Rect(positionX, positionY, selectableElement.Rect.width, 20), selectableElement.Rect.x + ", " + selectableElement.Rect.y);
        }
    }
}