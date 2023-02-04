using System;
using CodeBase.View;
using UnityEngine;

public abstract class Composite : NodeStandard, ISetterParent, IAddChild
{
    public event Action<INodeView> AddedChild;
    public event Action<INodeView> SetedParent;


    public Composite(NodeStyle style, WaypointsDrawer waypointsDrawer, Vector3 startPosition) : base(style, waypointsDrawer, startPosition)
    {
        
    }

    public void AddChild(INodeView child)
    {
        AddedChild?.Invoke(child);
    }
    
    public void SetParent(INodeView parent)
    {
        SetedParent?.Invoke(parent);
    }

}