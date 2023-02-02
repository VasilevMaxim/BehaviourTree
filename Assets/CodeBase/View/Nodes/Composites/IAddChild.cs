using System;
using CodeBase.View;

internal interface IAddChild
{
    void AddChild(INodeView child);
    event Action<INodeView> AddedChild;
}