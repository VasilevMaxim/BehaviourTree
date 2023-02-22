using System;
using CodeBase.View;

internal interface IHaveChild
{
    void AddChild(INodeView child);
    event Action<INodeView> AddedChild;
    
    void RemoveChild(INodeView child);
    event Action<INodeView> RemovedChild;
}