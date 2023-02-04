using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.View
{
    public class DrawerLinks
    {
        public IEnumerable<IEnumerable<Vector3>> WayControlPointPositions => _wayControlPointPositions;
        
        private List<List<Vector3>>_wayControlPointPositions;
        private List<(Waypoint start, Waypoint end)> _waypointsLinked;
        
        private readonly IPaverWay _paverWay;
        private readonly IDrawerLink _drawer;
        private readonly DrawerArrow _drawerArrow;

        public DrawerLinks(IPaverWay paverWay, 
                           IDrawerLink drawer,
                           DrawerArrow drawerArrow)
        {
            _paverWay = paverWay;
            _drawer = drawer;
            _drawerArrow = drawerArrow;

            _waypointsLinked = new List<(Waypoint start, Waypoint end)>();
            _wayControlPointPositions = new List<List<Vector3>>();
        }
        
        public void DrawFixedWays()
        {
            foreach (var way in _waypointsLinked)
            {
                var pointsWay = _paverWay.Pave(way.start.Position, way.end.Position);
                DrawWay(pointsWay);
            }
        }
        
        public void DrawWay(IEnumerable<Vector3> points)
        {
            var pointsArray = points.ToArray();
            _drawer.Draw(pointsArray);
            _drawerArrow.Draw(pointsArray[0], pointsArray[^1]);
        }
        
        public void DrawWay(Waypoint start, Vector2 end)
        {
            var pointsWay = _paverWay.Pave(start.Position, end);
            _drawer.Draw(pointsWay.ToArray());
            Debug.Log("asd");
            _drawerArrow.Draw(start.Position, end);
        }

        public void AddWay(Waypoint start, Waypoint end)
        {
            _waypointsLinked.Add((start, end));
        }
        
        public void RemoveWay(Waypoint start, Waypoint end)
        {
            _waypointsLinked.Remove((start, end));
        }
    }
    
    /*

    public class ControlLinker
    {
        private readonly IEnumerable<IUpdatable> _nodes;
        private Vector2 _mousePosition;
        private Vector2 _mousePositionDown;
        private bool _isDown;
        private readonly Vector2 _position;
        private readonly Vector2 _scale;

        private float _delta = 7;

        private List<(Vector2, Vector2)> _links = new ();
        private List<Vector3> _points;
        private IUpdatable _nodeCurrent;

        public ControlLinker(IEnumerable<IUpdatable> nodes)
        {
            _nodes = nodes;
            ControlHelper.MouseDown += ControlHelperOnMouseDown;
            ControlHelper.MouseUp += ControlHelperOnMouseUp;
        
            _scale = new Vector2(150, 70); 
        }

        private void ControlHelperOnMouseUp(Vector2 mousePosition)
        {
            if (IsMouseOnPoint())
            {
                _links.Add((_points[0], mousePosition));
            }
       
            _isDown = false;
        }

        private void ControlHelperOnMouseDown(Vector2 mousePosition)
        {
            _mousePosition = mousePosition;
            _mousePositionDown = mousePosition;
            _isDown = true;
        }

        private bool IsMouseOnPoint()
        {
            foreach (var node in _nodes)
            {
                if (node == _nodeCurrent) continue;
            
            
                if (ControlHelper.MousePosition.x < node.Position.x + node.Scale.x / 2 + _delta
                    && ControlHelper.MousePosition.x > node.Position.x + node.Scale.x / 2 - _delta
                    && ControlHelper.MousePosition.y < node.Position.y + _delta
                    && ControlHelper.MousePosition.y > node.Position.y - _delta)
                {
                    return true;
                }
                
                if (ControlHelper.MousePosition.x < node.Position.x + node.Scale.x / 2 + _delta
                    && ControlHelper.MousePosition.x > node.Position.x + node.Scale.x / 2 - _delta
                    && ControlHelper.MousePosition.y < node.Position.y + node.Scale.y + _delta
                    && ControlHelper.MousePosition.y > node.Position.y + node.Scale.y - _delta)
                {
                    return true;
                }
                
                if (ControlHelper.MousePosition.x < node.Position.x + _delta
                    && ControlHelper.MousePosition.x > node.Position.x - _delta
                    && ControlHelper.MousePosition.y < node.Position.y + node.Scale.y / 2 + _delta
                    && ControlHelper.MousePosition.y > node.Position.y + node.Scale.y / 2 - _delta)
                {
                    return true;
                }
                
                if (ControlHelper.MousePosition.x < node.Position.x + node.Scale.x + _delta
                    && ControlHelper.MousePosition.x > node.Position.x + node.Scale.x - _delta
                    && ControlHelper.MousePosition.y < node.Position.y + node.Scale.y / 2 + _delta
                    && ControlHelper.MousePosition.y > node.Position.y + node.Scale.y / 2 - _delta)
                {
                    return true;
                }
            }
        
            return false;
        }
    
    
        public void Update()
        {
            if (_isDown)
            {
                foreach (var node in _nodes)
                {
                    if (_mousePosition.x < node.Position.x + node.Scale.x / 2 + _delta
                        && _mousePosition.x > node.Position.x + node.Scale.x / 2 - _delta
                        && _mousePosition.y < node.Position.y + _delta
                        && _mousePosition.y > node.Position.y - _delta)
                    {
                        Link();
                        _nodeCurrent = node;
                    }
                
                    if (_mousePosition.x < node.Position.x + node.Scale.x / 2 + _delta
                        && _mousePosition.x > node.Position.x + node.Scale.x / 2 - _delta
                        && _mousePosition.y < node.Position.y + node.Scale.y + _delta
                        && _mousePosition.y > node.Position.y + node.Scale.y - _delta)
                    {
                        Link();
                        _nodeCurrent = node;
                    }
                
                    if (_mousePosition.x < node.Position.x + _delta
                        && _mousePosition.x > node.Position.x - _delta
                        && _mousePosition.y < node.Position.y + node.Scale.y / 2 + _delta
                        && _mousePosition.y > node.Position.y + node.Scale.y / 2 - _delta)
                    {
                        Link();
                        _nodeCurrent = node;
                    }
                
                    if (_mousePosition.x < node.Position.x + node.Scale.x + _delta
                        && _mousePosition.x > node.Position.x + node.Scale.x - _delta
                        && _mousePosition.y < node.Position.y + node.Scale.y / 2 + _delta
                        && _mousePosition.y > node.Position.y + node.Scale.y / 2 - _delta)
                    {
                        Link();
                        _nodeCurrent = node;
                    }
                }
            }

            if (_links.Count > 0)
            {
                foreach (var link in _links)
                {
                    var points = new List<Vector3>();
                    var tMaxX = link.Item1.x + (link.Item2.y - link.Item1.x) / 2;
                    var p1 = new Vector2(tMaxX, link.Item2.y);
                    var p2 = new Vector2(tMaxX, link.Item2.y);
        
                    for (float i = 0; i <= 1.1f; i += 0.1f)
                    {
                        var value = CalculateBezierPoint(link.Item1, p1, p2, link.Item2, i);
                        points.Add(value);
                    }
        
                    Handles.DrawAAPolyLine(Resources.Load<Texture2D>("2"), 1, points.ToArray());
                }
            }
        }


    
        private void Link()
        {
            _points = new List<Vector3>();
            var tMaxX = _mousePositionDown.x + (ControlHelper.MousePosition.x - _mousePositionDown.x) / 2;
            var p1 = new Vector2(tMaxX, _mousePositionDown.y);
            var p2 = new Vector2(tMaxX, ControlHelper.MousePosition.y);
        
            for (float i = 0; i <= 1.1f; i += 0.1f)
            {
                var value = CalculateBezierPoint(_mousePositionDown, p1, p2, ControlHelper.MousePosition, i);
                _points.Add(value);
            }
        
            Handles.DrawAAPolyLine(Resources.Load<Texture2D>("2"), 1, _points.ToArray());

            

        }
    }
    */
}