using UnityEditor;
using UnityEngine;

namespace CodeBase.View
{
    public class DrawerLink : IDrawerLink
    {
        private readonly int _width;
        private readonly Texture2D _texture2D;

        public DrawerLink(int width, Texture2D texture2D = null)
        {
            _width = width;
            _texture2D = texture2D;
        }
        
        public void Draw(params Vector3[] points)
        {
            if (_texture2D != null)
            {
                Handles.DrawAAPolyLine(_texture2D, _width, points);
            }
            else
            {
                Handles.DrawAAPolyLine(_width, points);
            }
        }
    }
}