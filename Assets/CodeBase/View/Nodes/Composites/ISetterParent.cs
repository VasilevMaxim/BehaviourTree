using System;
using CodeBase.View;

internal interface ISetterParent
{
    void SetParent(INodeView parent);
    event Action<INodeView> SetedParent;
}