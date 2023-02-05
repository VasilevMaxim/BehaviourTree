using UnityEditor;
using UnityEngine;

namespace CodeBase.View
{
    public class ScalableUIElement
    {
        private readonly IInputEventsView _inputEventsView;

        public ScalableUIElement(IInputEventsView inputEventsView)
        {
            _inputEventsView = inputEventsView;
            _inputEventsView.MouseDrag += InputEventsViewOnMouseDrag;
        }

        private void InputEventsViewOnMouseDrag(Vector2 mousePosition)
        {
            
        }

        public void Update(UIElement element)
        {
            GUI.DrawTexture(new Rect(element.Rect.position, new Vector2(20, 20)), Resources.Load<Texture2D>("Circle"));
            GUI.DrawTexture(new Rect(new Vector2(element.Rect.xMax, element.Rect.yMin), new Vector2(20, 20)), Resources.Load<Texture2D>("Circle"));
            GUI.DrawTexture(new Rect(new Vector2(element.Rect.xMin, element.Rect.yMax), new Vector2(20, 20)), Resources.Load<Texture2D>("Circle"));
            GUI.DrawTexture(new Rect(new Vector2(element.Rect.xMax, element.Rect.yMax), new Vector2(20, 20)), Resources.Load<Texture2D>("Circle"));
            
            EditorGUIUtility.AddCursorRect(new Rect(element.Rect.position, new Vector2(20, 20)), MouseCursor.SlideArrow);
            EditorGUIUtility.AddCursorRect(new Rect(new Vector2(element.Rect.xMax, element.Rect.yMin), new Vector2(20, 20)), MouseCursor.SlideArrow);
            EditorGUIUtility.AddCursorRect(new Rect(new Vector2(element.Rect.xMin, element.Rect.yMax), new Vector2(20, 20)), MouseCursor.SlideArrow);
            EditorGUIUtility.AddCursorRect(new Rect(new Vector2(element.Rect.xMax, element.Rect.yMax), new Vector2(20, 20)), MouseCursor.SlideArrow);
        }
    }
}