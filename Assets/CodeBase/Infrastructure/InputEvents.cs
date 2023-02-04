using System;
using CodeBase.View;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class InputEvents : IInputEventsView
    {
        private Action _repaint;
        private Vector2 _deltaScrollWindow;

        public Vector2 MousePosition { get; private set; }
        public bool IsMouseDrag { get; private set; }
        
        public event Action<Vector2> MouseDown;
        public event Action<Vector2> MouseRightDown;
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
            MousePosition = e.mousePosition - _deltaScrollWindow;
            switch (e.type)
            {
                case EventType.Layout:
                    Layout?.Invoke();
                    break;
                case EventType.MouseDown:
                    if (e.button == 1)
                    {
                        MouseRightDown?.Invoke(MousePosition);
                    }
                    else
                    {
                        MouseDown?.Invoke(MousePosition);
                    }
                    _repaint?.Invoke();
                    break;
                case EventType.MouseDrag:
                    MouseDrag?.Invoke(MousePosition);
                    IsMouseDrag = true;
                    _repaint?.Invoke();
                    break;

                case EventType.MouseUp:
                    MouseUp?.Invoke(MousePosition);
                    IsMouseDrag = false;
                    _repaint?.Invoke();
                    break;
            }
        }
        
        public void SetDeltaScrollWindow(Vector2 delta)
        {
            _deltaScrollWindow = delta;
        }
    }
}