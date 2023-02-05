using UnityEditor;
using UnityEngine;

namespace CodeBase.View
{
    public class BlackboardView : ISelectable
    {
        
        private const string SequenceText = "Blackboard";
        
        public Rect Rect { get; set; }
        
        private readonly BlackboardStyle _style;
        
        public BlackboardView(BlackboardStyle style, Vector2 startPosition)
        {
            _style = style;
            Rect = Rect.GetRectNewPosition(startPosition);
            Rect = Rect.GetRectNewSize(style.Scale);
        }

        public void Update()
        {
            Handles.DrawSolidRectangleWithOutline(Rect, _style.ColorDefault, new Color(1, 1, 1, 0.6f));
            GUI.Label(Rect, SequenceText);
        }

        public void Select()
        {
            
        }

        public void Deselect()
        {
            
        }
    }
}