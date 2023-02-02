using System;
using CodeBase.View;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class InputEvents : IInputEventsView
    {
        private Action _repaint;
        
        public Vector2 MousePosition { get; private set; }
        public bool IsMouseDrag { get; private set; }
        
        public event Action<Vector2> MouseDown;
        public event Action<Vector2> MouseDrag;
        public event Action<Vector2> MouseUp;
        public event Action Layout;
        
        public InputEvents(Action repaint)
        {
            _repaint = repaint;
        }
        
        public void Check()
        {
            Event e = Event.current;
            MousePosition = e.mousePosition;
            switch (e.type)
            {
                case EventType.Layout:
                    Layout?.Invoke();
                    break;
                case EventType.MouseDown:
                    MouseDown?.Invoke(e.mousePosition);
                    _repaint?.Invoke();
                    break;
                case EventType.MouseDrag:
                    MouseDrag?.Invoke(e.mousePosition);
                    IsMouseDrag = true;
                    _repaint?.Invoke();
                    break;

                case EventType.MouseUp:
                    MouseUp?.Invoke(e.mousePosition);
                    IsMouseDrag = false;
                    _repaint?.Invoke();
                    break;
            }

        }
    }
}