using System;
using UnityEngine;

namespace CodeBase.View
{
    public interface IInputEventsView
    {
        public Vector2 MousePosition { get; }
        public bool IsMouseDrag { get; }
        
        public event Action<Vector2> MouseDown;
        public event Action<Vector2> MouseDrag;
        public event Action<Vector2> MouseUp;
        public event Action Layout;
    }
}