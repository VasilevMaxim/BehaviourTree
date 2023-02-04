using System;
using UnityEngine;

namespace CodeBase.View
{
    public interface IInputEventsView
    {
        void SetDeltaScrollWindow(Vector2 delta);
        
        Vector2 MousePosition { get; }
        bool IsMouseDrag { get; }
        
        event Action<Vector2> MouseDown;
        event Action<Vector2> MouseRightDown;
        event Action<Vector2> MouseDrag;
        event Action<Vector2> MouseUp;
        event Action Layout;
    }
}