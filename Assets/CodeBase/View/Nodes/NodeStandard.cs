using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.View
{
    public abstract class NodeStandard : INodeView
    {
        public Rect Rect { get; set; }
        protected Color ColorCurrent;
            
        protected readonly NodeStyle Style;
        protected readonly WaypointsDrawer WaypointsDrawer;


        public NodeStandard(NodeStyle style, WaypointsDrawer waypointsDrawer, Vector3 startPosition)
        {
            Style = style;
            WaypointsDrawer = waypointsDrawer;
            Rect = new Rect(startPosition, Style.Scale);
        
            ColorCurrent = Style.ColorDefault;
        }

        public abstract void Update();

        public IEnumerable<Waypoint> GetWaypoints()
        {
            return WaypointsDrawer.Waypoints;
        }

        public void Select()
        {
            ColorCurrent = Style.ColorSelected;
        }
        
        public void Deselect()
        {
            ColorCurrent = Style.ColorDefault;
        }
    }
}