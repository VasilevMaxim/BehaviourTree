using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.View
{
    public interface IGetterWaypoints
    {
        IEnumerable<Waypoint> GetWaypoints();
    }
    
    public interface INodeView : ISelectable, IGetterWaypoints
    {
        
    }
}