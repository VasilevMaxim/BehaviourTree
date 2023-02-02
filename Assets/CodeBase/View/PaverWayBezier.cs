using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.View
{
    public class PaverWayBezier : IPaverWay
    {
        private readonly float _tBezier;
        private List<Vector3> _points;

        public PaverWayBezier(float tBezier = 0.1f)
        {
            _tBezier = tBezier;
        }
        
        public IEnumerable<Vector3> Pave(Vector2 startPosition, Vector2 endPosition)
        {
            _points = new List<Vector3>();
            var tMaxX = startPosition.x + (endPosition.x - startPosition.x) / 2;
            var p1 = new Vector2(tMaxX, startPosition.y);
            var p2 = new Vector2(tMaxX,endPosition.y);
        
            for (float t = 0; t <= 1.1f; t += _tBezier)
            {
                var value = CalculateBezierPoint(startPosition, p1, p2, endPosition, t);
                _points.Add(value);
            }

            return _points;
        }
        
        private Vector2 CalculateBezierPoint(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t) 
        {
            float u = 1 - t;
            float tt = t * t, uu = u * u;
            float uuu = uu * u, ttt = tt * t;
            return new Vector2(
                (uuu * p0.x) + (3 * uu * t * p1.x) + (3 * u * tt * p2.x) + (ttt * p3.x),
                (uuu * p0.y) + (3 * uu * t * p1.y) + (3 * u * tt * p2.y) + (ttt * p3.y)
            );
        }
    }
}