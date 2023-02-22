using System;
using CodeBase.View;
using UnityEngine;

public abstract class Composite : NodeStandard, ISetterParent, IHaveChild
{
    public event Action<INodeView> AddedChild;
    public event Action<INodeView> SetedParent;
    public event Action<INodeView> RemovedChild;
    public event Action RemovedParent;
    public event Action RemovedAllChildren;
    
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
    
    public void RemoveChild(INodeView child)
    {
        RemovedChild?.Invoke(child);
    }
    
    public void RemoveAllChildren()
    {
        RemovedAllChildren?.Invoke();
    }
    
    public void RemoveParent()
    {
        RemovedParent?.Invoke();
    }
}