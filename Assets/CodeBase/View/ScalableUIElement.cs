using UnityEditor;
using UnityEngine;

namespace CodeBase.View
{
    public class ScalableUIElement
    {
        private readonly IInputEventsView _inputEventsView;
        private UIElement _element;
        private Vector2 _mouseDownPosition;
        private Rect _rectDown;

        public ScalableUIElement(IInputEventsView inputEventsView)
        {
            _inputEventsView = inputEventsView;
            _inputEventsView.MouseDrag += InputEventsViewOnMouseDrag;
            _inputEventsView.MouseDown += InputEventsViewOnMouseDown;
        }

        private void InputEventsViewOnMouseDown(Vector2 mousePosition)
        {
            _mouseDownPosition = mousePosition;

            if (_element != null)
            {
                if (_element is  BlackboardView)
                {
                    _rectDown = _element.Rect;
                }
            }
        }

        private void InputEventsViewOnMouseDrag(Vector2 mousePosition)
        { 
            if (_element == null)
            {
                return;
            }
            
            if (_element is not BlackboardView)
            {
                return;
            }
            
            var size = new Vector2(20, 20);
            var halfSize = size / 2;
            
            var rect = new Rect(new Vector2(_element.Rect.xMin - halfSize.x, _element.Rect.yMin - halfSize.y), size);
            var rect2 = new Rect(new Vector2(_element.Rect.xMax - halfSize.x, _element.Rect.yMin - halfSize.y), size);
            var rect3 = new Rect(new Vector2(_element.Rect.xMin - halfSize.x, _element.Rect.yMax - halfSize.y), size);
            var rect4 = new Rect(new Vector2(_element.Rect.xMax - halfSize.x, _element.Rect.yMax - halfSize.y), size);
            
            var raz = ( mousePosition - _mouseDownPosition);
            var obrRaz = (_mouseDownPosition - mousePosition);
            
            if (mousePosition.IsHoverRect(rect))
            {
                _element.Rect = new Rect(_rectDown.x - obrRaz.x, _rectDown.y - obrRaz.y, _rectDown.width + obrRaz.x,_rectDown.height + obrRaz.y);
            }
            
            if (mousePosition.IsHoverRect(rect2))
            {
                _element.Rect = new Rect(_rectDown.x, _rectDown.y - obrRaz.y, _rectDown.width + raz.x,_rectDown.height + obrRaz.y);
            }
            
            if (mousePosition.IsHoverRect(rect3))
            {
                _element.Rect = new Rect(_rectDown.x - obrRaz.x, _rectDown.y, _rectDown.width + obrRaz.x,_rectDown.height + raz.y);
            }

            if (mousePosition.IsHoverRect(rect4))
            {
                _element.Rect = new Rect(_rectDown.x, _rectDown.y, _rectDown.width + raz.x,_rectDown.height + raz.y);
            }
        }

        public void Update(UIElement element)
        {
            if (element == null)
            {
                return;
            }
            
            if (element is not BlackboardView)
            {
                return;
            }
            
            _element = element;
            var size = new Vector2(20, 20);
            var halfSize = size / 2;
            
            GUI.DrawTexture(new Rect(new Vector2(element.Rect.xMin - halfSize.x, element.Rect.yMin - halfSize.y), size), Resources.Load<Texture2D>("Circle"));
            GUI.DrawTexture(new Rect(new Vector2(element.Rect.xMax - halfSize.x, element.Rect.yMin - halfSize.y), size), Resources.Load<Texture2D>("Circle"));
            GUI.DrawTexture(new Rect(new Vector2(element.Rect.xMin - halfSize.x, element.Rect.yMax - halfSize.y), size), Resources.Load<Texture2D>("Circle"));
            GUI.DrawTexture(new Rect(new Vector2(element.Rect.xMax - halfSize.x, element.Rect.yMax - halfSize.y), size), Resources.Load<Texture2D>("Circle"));
            
            EditorGUIUtility.AddCursorRect(new Rect(new Vector2(element.Rect.xMin - halfSize.x, element.Rect.yMin - halfSize.y), size), MouseCursor.SlideArrow);
            EditorGUIUtility.AddCursorRect(new Rect(new Vector2(element.Rect.xMax - halfSize.x, element.Rect.yMin - halfSize.y), size), MouseCursor.SlideArrow);
            EditorGUIUtility.AddCursorRect(new Rect(new Vector2(element.Rect.xMin - halfSize.x, element.Rect.yMax - halfSize.y), size), MouseCursor.SlideArrow);
            EditorGUIUtility.AddCursorRect(new Rect(new Vector2(element.Rect.xMax - halfSize.x, element.Rect.yMax - halfSize.y), size), MouseCursor.SlideArrow);
        }
    }
}