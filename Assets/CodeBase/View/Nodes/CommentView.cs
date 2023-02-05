using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CodeBase.View
{
    public class CommentView : INodeView
    {
        private const string RootText = "Comment";
        
        public Rect Rect { get; set; }
        
        public event Action<INodeView> AddedChild;

        private Color _colorCurrent;
        private GUIStyle _styleLabel;

        private readonly NodeStyle _style;
        private readonly WaypointsDrawer _waypointsDrawer;
        private string _text;

        public CommentView(NodeStyle style, Vector3 startPosition)
        {
            _style = style;
            Rect = Rect.GetRectNewPosition(startPosition);
            Rect = Rect.GetRectNewSize(_style.Scale);
        
            _colorCurrent = _style.ColorDefault;
        }

        public void Update() 
        {
            _text = GUI.TextArea(Rect, _text);
        }

        public void AddChild(INodeView child)
        {
            AddedChild?.Invoke(child);
        }

        public IEnumerable<Waypoint> GetWaypoints()
        {
            return null;
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