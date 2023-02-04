using System;
using System.Collections.Generic;
using CodeBase.View;
using UnityEngine;


public abstract class Composite : IComposite
{
  
    public Rect Rect { get; set; }
    
    public event Action<INodeView> AddedChild;
    public event Action<INodeView> SetedParent;
    
    protected readonly NodeStyle Style;
    protected Color ColorCurrent;
    
    protected readonly WaypointsDrawer WaypointsDrawer;

    public Composite(NodeStyle style, WaypointsDrawer waypointsDrawer, Vector3 startPosition)
    {
        Style = style;
        WaypointsDrawer = waypointsDrawer;
        Rect = new Rect(startPosition, Style.Scale);
        
        ColorCurrent = Style.ColorDefault;
    }

    public abstract void Update();

    public void AddChild(INodeView child)
    {
        AddedChild?.Invoke(child);
    }
    
    public void SetParent(INodeView parent)
    {
        SetedParent?.Invoke(parent);
    }

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