using UnityEditor;
using UnityEngine;

namespace CodeBase.View
{
    public class DrawerArrow
    {
        private Vector2 _line1;
        private Vector2 _line2;
        
        private readonly int _lengthBigPart;
        private readonly int _lengthSmallPart;
        private readonly int _width;

        public DrawerArrow(int lengthBigPart = 8, int lengthSmallPart = 6, int width = 1)
        {
            _lengthSmallPart = lengthSmallPart;
            _width = width;
            _lengthBigPart = lengthBigPart;
        }

        public void Draw(Vector2 startPosition, Vector2 endPosition)
        {
            var absX = Mathf.Abs(endPosition.x - startPosition.x);
            var absY = Mathf.Abs(endPosition.y - startPosition.y);

            if (absX > absY)
            {
                var deltaX = startPosition.x < endPosition.x ? _lengthBigPart : -_lengthBigPart;
                _line1 = new Vector2(endPosition.x + deltaX, endPosition.y + _lengthSmallPart);
                _line2 = new Vector2(endPosition.x + deltaX, endPosition.y - _lengthSmallPart);
            }
            else
            {
                var deltaY = startPosition.y < endPosition.y ? _lengthBigPart : -_lengthBigPart;
                _line1 = new Vector2(endPosition.x + _lengthSmallPart, endPosition.y + deltaY);
                _line2 = new Vector2(endPosition.x - _lengthSmallPart, endPosition.y + deltaY);
            }
            
            Handles.DrawAAPolyLine(_width, _line1, endPosition);
            Handles.DrawAAPolyLine(_width, _line2, endPosition);
        }
    }
}