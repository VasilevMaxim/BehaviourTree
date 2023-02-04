using UnityEditor;
using UnityEngine;

namespace CodeBase.View
{
    public class StatusBar
    {
        private readonly WorkspaceWindow _workspaceWindow;
        private GUIStyle _skinMenuBarButton;

        public StatusBar(WorkspaceWindow workspaceWindow)
        {
            _workspaceWindow = workspaceWindow;
        }

        public void Update()
        {
            var imageScale = EditorGUIUtility.IconContent("d_ScaleTool").image;
            var imagePosition = EditorGUIUtility.IconContent("d_AvatarPivot").image;

            var styleImage = new GUIStyle(GUI.skin.label)
            {
                margin = { left = 0, right = 0, bottom = GUI.skin.label.margin.bottom, top = GUI.skin.label.margin.top},
                padding = { left = 0, right = 1, bottom = GUI.skin.label.padding.bottom, top = GUI.skin.label.margin.top},
            };
            
            var styleScale = new GUIStyle(GUI.skin.label)
            {
                margin = { left = 0, right = 0, bottom = GUI.skin.label.margin.bottom, top = GUI.skin.label.margin.top},
                padding = { left = 0, right = 4, bottom = GUI.skin.label.padding.bottom, top = GUI.skin.label.margin.top},
            };
            
            var stylePosition = new GUIStyle(GUI.skin.label)
            {
                margin = { left = 0, right = 0, bottom = GUI.skin.label.margin.bottom, top = GUI.skin.label.margin.top},
                padding = { left = 0, right = 10, bottom = GUI.skin.label.padding.bottom, top = GUI.skin.label.margin.top},
            };

            GUILayout.BeginVertical();
            GUILayout.FlexibleSpace();
            GUILayout.BeginHorizontal(EditorStyles.toolbar, GUILayout.Width(Screen.width));
            GUILayout.FlexibleSpace();
            GUILayout.BeginHorizontal();
            
            //GUILayout.Label(imagePosition, styleImage);
            //GUILayout.Label((int) _workspaceWindow.RectScale.x + "x" + (int) _workspaceWindow.RectScale.y, stylePosition);
            
            GUILayout.Label(imageScale, styleImage, GUILayout.Width(16));
            GUILayout.Label((int) _workspaceWindow.RectScale.width + "x" + (int) _workspaceWindow.RectScale.height, styleScale);
            
            GUILayout.EndHorizontal();
            GUILayout.EndHorizontal();
            
            GUILayout.EndVertical();
        }
    }
}