using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.View
{
    public interface IPaverWay
    {
        IEnumerable<Vector3> Pave(Vector2 startPosition, Vector2 endPosition);
    }
}