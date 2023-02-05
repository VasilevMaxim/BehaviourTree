﻿using System;
using UnityEditor;
using UnityEngine;

namespace CodeBase.View
{
    public class MenuBar
    {
        private GUIStyle _skinMenuBarButton;

        public event Action AddingSequence;
        public event Action AddingSelector;
        public event Action AddingBlackboard;
        public event Action AddingComment;
        
        public void Update()
        {
            _skinMenuBarButton = new GUIStyle(GUI.skin.button)
            {
                fontSize = 8,
                margin = { left = 0, right = 0, bottom = 0, top = 0},
                padding = { left = 0, right = 0, bottom = 0, top = 0},
            };
            
            _skinMenuBarButton.normal.background = Texture2D.whiteTexture;
            _skinMenuBarButton.hover.background = Texture2D.whiteTexture;
            _skinMenuBarButton.active.background = Texture2D.whiteTexture;
            _skinMenuBarButton.normal.textColor = Color.black;
            _skinMenuBarButton.hover.textColor = Color.black;
            _skinMenuBarButton.active.textColor = Color.black;
            
            var styleBox = new GUIStyle(EditorStyles.toolbar)
            {
                margin = new RectOffset(0, 0, 0, 0),
                padding = { left = 0, right = 0, bottom = 0, top = 0},
                fixedHeight = 0
            };
            
            var styleButton = new GUIStyle(EditorStyles.toolbarButton)
            {
                margin = new RectOffset(0, 0, 0, 0),
                padding = { left = 0, right = 0, bottom = 0, top = 0},
                fixedHeight = 0
            };
            
            GUILayout.BeginHorizontal(EditorStyles.toolbar, GUILayout.Width(Screen.width));
            GUILayout.BeginHorizontal(GUILayout.Width(190));
            GUILayout.Button("Open", EditorStyles.toolbarButton);
            GUILayout.Button("Save", EditorStyles.toolbarButton);
            GUILayout.Button("Save As", EditorStyles.toolbarButton);
            GUILayout.EndHorizontal();
            GUILayout.EndHorizontal();
            
            GUILayout.BeginHorizontal(styleBox, GUILayout.Width(Screen.width * 0.8f), GUILayout.Height(50));
            
            if (GUILayout.Button("Sequence", styleButton, GUILayout.Width(90), GUILayout.Height(48)))
            {
                AddingSequence?.Invoke();
            }

            if (GUILayout.Button("Selector", styleButton, GUILayout.Width(90), GUILayout.Height(48)))
            {
                AddingSelector?.Invoke();
            }
            
            GUILayout.Button("Decorator", styleButton, GUILayout.Width(90), GUILayout.Height(48));

            if (GUILayout.Button("Blackboard", styleButton, GUILayout.Width(90), GUILayout.Height(48)))
            {
                AddingBlackboard?.Invoke();
            }
            
            if (GUILayout.Button("Comment", styleButton, GUILayout.Width(90), GUILayout.Height(48)))
            {
                AddingComment?.Invoke();
            }
            
            GUILayout.EndHorizontal();
        }
    }
}