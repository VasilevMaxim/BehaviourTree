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
            foreach (var node in _workspace.UIElements.OfType<IGetterWaypoints>())
            {
                _waypointDown = GetDownWaypoint(node, mousePosition);
                _nodeViewDown = node as INodeView;
                
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
            
            foreach (var getterWaypoints in _workspace.UIElements.OfType<IGetterWaypoints>())
            {
                var waypointUp = GetDownWaypoint(getterWaypoints, mousePosition);
                if (waypointUp != null)
                {
                    _drawerLinks.AddWay(_waypointDown, waypointUp);

                    if (getterWaypoints is INodeView nodeView)
                    {
                        if (_nodeViewDown is IAddChild addChild)
                        {
                            addChild.AddChild(nodeView);
                        }

                        if (_nodeViewDown is ISetterParent setterParent)
                        {
                            setterParent.SetParent(nodeView);
                        }
                    }
                }
            }
        }
        
        private Waypoint GetDownWaypoint(IGetterWaypoints getterWaypoints, Vector2 mousePosition)
        {
            var waypoints = getterWaypoints.GetWaypoints();
            if (waypoints == null)
            {
                return null;
            }
            
            foreach (var waypoint in waypoints)
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