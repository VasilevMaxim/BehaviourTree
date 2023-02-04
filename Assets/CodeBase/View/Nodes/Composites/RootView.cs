using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CodeBase.View
{
    public class RootView : INodeView, IAddChild
    {
        private const string RootText = "Root";
        
        public Rect Rect { get; set; }
        
        public event Action<INodeView> AddedChild;

        private Color _colorCurrent;
        private GUIStyle _styleLabel;

        private readonly NodeStyle _style;
        private readonly WaypointsDrawer _waypointsDrawer;

        public RootView(NodeStyle style, WaypointsDrawer waypointsDrawer, Vector3 startPosition)
        {
            _style = style;
            _waypointsDrawer = waypointsDrawer;
            Rect = Rect.GetRectNewPosition(startPosition);
            Rect = Rect.GetRectNewSize(_style.Scale);
        
            _colorCurrent = _style.ColorDefault;
        }

        public void Update() 
        {
            _styleLabel ??= new GUIStyle(GUI.skin.label)
            {
                alignment = TextAnchor.MiddleCenter
            };

            EditorGUI.DrawRect(Rect, _colorCurrent);
            _waypointsDrawer.Move(_style.Scale, Rect.position);
            GUI.Label(Rect, RootText, _styleLabel);
        }

        public void AddChild(INodeView child)
        {
            AddedChild?.Invoke(child);
        }

        public IEnumerable<Waypoint> GetWaypoints()
        {
            return _waypointsDrawer.Waypoints;
        }

        public void Select()
        {
            _colorCurrent = _style.ColorSelected;
        }
        
        public void Deselect()
        {
            _colorCurrent = _style.ColorDefault;
        }

    }
}