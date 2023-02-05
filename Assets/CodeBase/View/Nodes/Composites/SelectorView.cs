using UnityEditor;
using UnityEngine;

namespace CodeBase.View
{
    public class SelectorView : Composite
    {
        private const string SequenceText = "Selector";
        private GUIStyle _styleLabel;

        public SelectorView(NodeStyle style, WaypointsDrawer waypointsDrawer, Vector2 startPosition) : base(style, waypointsDrawer, startPosition)
        {
            
        }

        public override void Update()
        {
            _styleLabel ??= new GUIStyle(GUI.skin.label)
            {
                alignment = TextAnchor.MiddleCenter
            };

            EditorGUI.DrawRect(Rect, ColorCurrent);
            WaypointsDrawer.Move(Style.Scale, Rect.position);
            GUI.Label(Rect, SequenceText, _styleLabel);
        }
    }
}