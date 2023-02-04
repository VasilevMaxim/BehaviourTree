using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace CodeBase.View
{
    public class ContextMenu
    {
        public event Action<INodeView> AddedTask;
        
        private GenericMenu _genericMenu;
        
        private readonly WorkspaceWindow _workspaceWindow;
        private readonly IInputEventsView _inputEventsView;
        private readonly IEnumerable<Type> _typeTasks;

        public ContextMenu(WorkspaceWindow workspaceWindow, IInputEventsView inputEventsView)
        {
            _workspaceWindow = workspaceWindow;
            _inputEventsView = inputEventsView;
            
            _typeTasks = GetTypesWithAttribute<TaskBTAttribute>(AppDomain.CurrentDomain.GetAssemblies());
            _inputEventsView.MouseRightDown += InputEventsViewOnMouseRightDown;
            
            InitializeGenericMenu();
        }
 
        private void InitializeGenericMenu()
        {
            _genericMenu = new GenericMenu();
            foreach (var type in _typeTasks)
            {
                _genericMenu.AddItem(new GUIContent("Tasks/" + type.Name), false, () => AddedTask?.Invoke(CreateNodeInstance(type)));
            }
        }

        private INodeView CreateNodeInstance(Type type)
        {
            return (INodeView) Activator.CreateInstance(type, Resources.Load<NodeStyle>("StyleSequence"), new WaypointsDrawer(4), new Vector3(300, 100, 0));
        }


        private void InputEventsViewOnMouseRightDown(Vector2 mousePosition)
        {
            if (mousePosition.IsHoverRect(_workspaceWindow.Rect))
            {
                _genericMenu.ShowAsContext();
            }
        }
        
        private static IEnumerable<Type> GetTypesWithAttribute<TAttribute>(Assembly[] assemblies) where TAttribute : Attribute
        {
            return assemblies.SelectMany(s => s.GetTypes())
                             .Where(type => type.GetCustomAttributes(typeof(TAttribute), true).Length > 0);
        }
    }
}