using UnityEditor;
using UnityEngine;

namespace CodeBase.View
{
    [TaskBT]
    public class MoveTo : NodeStandard
    {
        private const string SequenceText = "MoveTo";
        private GUIStyle _styleLabel;
        
        public MoveTo(NodeStyle style, WaypointsDrawer waypointsDrawer, Vector3 startPosition) : base(style, waypointsDrawer, startPosition)
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