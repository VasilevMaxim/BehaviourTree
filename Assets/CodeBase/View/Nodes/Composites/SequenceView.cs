﻿using UnityEditor;
using UnityEngine;

namespace CodeBase.View
{
    public class SequenceView : Composite
    {
        private const string SequenceText = "Sequence";
        private GUIStyle _styleLabel;

        public SequenceView(NodeStyle style, WaypointsDrawer waypointsDrawer, Vector2 startPosition) : base(style, waypointsDrawer, startPosition)
        {

        }

        public override void Update()
        {
            _styleLabel ??= new GUIStyle(GUI.skin.label)
            {
                alignment = TextAnchor.MiddleCenter
            };

            EditorGUI.DrawRect(new Rect(Position, Scale), ColorCurrent);
            WaypointsDrawer.Move(Style.Scale, Position);
            GUI.Label(new Rect(Position, Scale), SequenceText, _styleLabel);
        }
    }
}