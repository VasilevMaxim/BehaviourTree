using System;
using System.Linq;
using UnityEngine;

namespace CodeBase.View
{
    public class SelectingNodes : IDisposable
    {
        public ISelectable UIElementSelected { get; private set; }
        
        private readonly Workspace _workspace;
        private readonly IInputEventsView _inputEventsView;

        public SelectingNodes(Workspace workspace, IInputEventsView inputEventsView)
        {
            _workspace = workspace;
            _inputEventsView = inputEventsView;
        }

        public void Initialize()
        {
            _inputEventsView.MouseDown += InputEventsViewOnMouseDown;
            _inputEventsView.MouseRightDown += InputEventsViewOnMouseRightDown;
        }
        
        public void Dispose()
        {
            _inputEventsView.MouseDrag -= InputEventsViewOnMouseDown;
        }
        
        private void InputEventsViewOnMouseDown(Vector2 mousePosition)
        {
            _workspace.UIElements.OfType<ISelectable>().ForEach(node => node.Deselect());
            UIElementSelected = null;
            
            foreach (var uiElement in _workspace.UIElements)
            {
                if (uiElement is IGetterWaypoints getterWaypoints)
                {
                    var waypoints = getterWaypoints.GetWaypoints();
                    if (waypoints != null)
                    {
                        foreach (var waypoint in waypoints)
                        {
                            if (Vector2.Distance(mousePosition, waypoint.Position) < waypoint.DeltaSize)
                            {
                                return;
                            }
                        }
                    }
                }

                if (uiElement is ISelectable selectable)
                {
                    if (mousePosition.IsHoverRect(uiElement.Rect))
                    {
                        selectable.Select();
                        UIElementSelected = selectable;
                    }
                }
            }
        }
        
        private void InputEventsViewOnMouseRightDown(Vector2 mousePosition)
        {
            _workspace.UIElements.OfType<ISelectable>().ForEach(node => node.Deselect());
            UIElementSelected = null;
        }
    }
}