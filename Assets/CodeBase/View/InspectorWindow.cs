using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CodeBase.View
{
    public interface IShow
    {
        string Name { get; }
    }

    public class S : IShow
    {
        public string Name => "Main settings";
    }
    
    public class InspectorWindow : Window
    {
        private Vector2 _scrollPosition;
    
        public InspectorWindow() : base()
        {
            AddBlockParameters(new S());
        }
        
        private List<bool> _isShows = new();
        private List<IShow> _shows = new();
        
        public void AddBlockParameters(IShow shows)
        {
            _isShows.Add(false);
            _shows.Add(shows);
        }

        public void Update()
        {
            var styleBox = new GUIStyle(EditorStyles.toolbar)
            {
                margin = new RectOffset(0, 0, 0, 0),
                padding = { left = 0, right = 0, bottom = 0, top = 0},
                fixedHeight = 0,
                border = { left = 2, right = 2, bottom = 0, top = 0},
                fontSize = 12
            };

            var position = new Vector2(Screen.width * 0.8f, 21);
            var scale = new Vector2(Screen.width * 0.2f, Screen.height - 80);
            GUI.Box(new Rect(position,scale), GUIContent.none, styleBox);
            
            var imageInfo = EditorGUIUtility.IconContent("d_Preset.Context@2x").image;
            GUI.Box(new Rect(new Vector2(position.x, position.y),new Vector2(80, 20)), "Info", styleBox);

            var styleVertical = new GUIStyle(GUI.skin.box)
            {
                margin = new RectOffset((int)(Screen.width * 0.8f), 0, 0, 0),
                padding = { left = 0, right = 0, bottom = 0, top = 0},
                fixedHeight = 0,
                border = { left = 2, right = 2, bottom = 0, top = 0},
                fontSize = 12
            };
            
            var styleButton = new GUIStyle(GUI.skin.button)
            {
                margin = new RectOffset(0, GUI.skin.button.margin.right, 0, 0),
                padding = { left = 0, right = 0, bottom = 0, top = 0},
                border = { left = 0, right = 0, bottom = 0, top = 0},
            };
            
            GUILayout.BeginVertical(styleVertical);
            
            GUILayout.BeginVertical();
            

            for (int i = 0; i < _isShows.Count; i++)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(_shows[i].Name);
                GUILayout.FlexibleSpace();
                if (GUILayout.Button(imageInfo, styleButton, GUILayout.Width(25), GUILayout.Height(25)))
                {
                    _isShows[i] = !_isShows[i];
                }
                GUILayout.EndHorizontal();

                if (_isShows[i])
                {
                    GUILayout.BeginVertical();
                    GUILayout.Button("Info");
                    GUILayout.Button("Info");
                    GUILayout.EndVertical();
                }
            }
            
  

            GUILayout.EndVertical();
            
            GUILayout.EndVertical();
            
            
        }
    }
}