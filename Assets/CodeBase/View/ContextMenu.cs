using UnityEditor;
using UnityEngine;

namespace CodeBase.View
{
    public static class Vector2Extensions
    {
        public static bool IsHoverRect(this Vector2 vector2, Rect rect)
        {
            return vector2.x > rect.x
                   && vector2.x < rect.x + rect.width
                   && vector2.y > rect.y
                   && vector2.y < rect.y + rect.height;
        }
    }
    
    public class ContextMenu
    {
        private readonly WorkspaceWindow _workspaceWindow;
        private readonly IInputEventsView _inputEventsView;

        public ContextMenu(WorkspaceWindow workspaceWindow, IInputEventsView inputEventsView)
        {
            _workspaceWindow = workspaceWindow;
            _inputEventsView = inputEventsView;
            
            _inputEventsView.MouseRightDown += InputEventsViewOnMouseRightDown;
        }

        private void InputEventsViewOnMouseRightDown(Vector2 mousePosition)
        {
            if (mousePosition.IsHoverRect(_workspaceWindow.Rect))
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent("Tasks/Tasl"), false, () => {});
                menu.AddItem(new GUIContent("Tasks/Tasl2"), false, () => {});
                menu.ShowAsContext();
            }
        }
    }
}