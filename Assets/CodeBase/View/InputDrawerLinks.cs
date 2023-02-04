using System;
using System.Linq;
using UnityEngine;

namespace CodeBase.View
{
    public class InputDrawerLinks
    {
        private Waypoint _waypointDown;
        private INodeView _nodeViewDown;
        private Vector2 _mousePositionDrag;
        private bool _isDrag;
        
        private readonly Workspace _workspace;
        private readonly DrawerLinks _drawerLinks;
        private readonly IInputEventsView _inputEventsView;

        public InputDrawerLinks(Workspace workspace, 
                                DrawerLinks drawerLinks,
                                IInputEventsView inputEventsView)
        {
            _workspace = workspace;
            _drawerLinks = drawerLinks;
            _inputEventsView = inputEventsView;

            _inputEventsView.MouseDown += InputEventsOnMouseDown;
            _inputEventsView.MouseUp += InputEventsOnMouseUp;
        }

        public void Draw()
        {
            _drawerLinks.DrawFixedWays();

            if (_inputEventsView.IsMouseDrag == true && _waypointDown != null)
            {
                _drawerLinks.DrawWay(_waypointDown, _inputEventsView.MousePosition);
            }
        }
        
        private void InputEventsOnMouseDown(Vector2 mousePosition)
        {
            foreach (var node in _workspace.Nodes)
            {
                _waypointDown = GetDownWaypoint(node, mousePosition);
                _nodeViewDown = node;
                
                if (_waypointDown != null)
                {
                    return;
                }
            }
            
            foreach (var wayControlPoint in _drawerLinks.WayControlPointPositions.SelectMany(_ => _))
            {
                if (Vector2.Distance(mousePosition, wayControlPoint) < 3)
                {
                    Debug.Log("ASYKA");
                }
            }
        }
        
        private void InputEventsOnMouseUp(Vector2 mousePosition)
        {
            if (_waypointDown == null)
            {
                return;
            }
            
            foreach (var node in _workspace.Nodes)
            {
                var waypointUp = GetDownWaypoint(node, mousePosition);
                if (waypointUp != null)
                {
                    _drawerLinks.AddWay(_waypointDown, waypointUp);
                    
                    if (_nodeViewDown is IAddChild addChild)
                    {
                        addChild.AddChild(node);
                    }
                    
                    if (_nodeViewDown is ISetterParent setterParent)
                    {
                        setterParent.SetParent(node);
                    }
                }
            }
        }
        
        private Waypoint GetDownWaypoint(INodeView nodeView, Vector2 mousePosition)
        {
            foreach (var waypoint in nodeView.GetWaypoints())
            {
                var distance = Vector2.Distance(mousePosition, waypoint.Position);
                if (distance < waypoint.DeltaSize)
                {
                    return waypoint;
                }
            }
            
            return null;
        }
    }
}