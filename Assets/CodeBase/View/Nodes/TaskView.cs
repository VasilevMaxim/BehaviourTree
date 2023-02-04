using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CodeBase.View
{
    public class TaskView : UIElement, IUpdatable
    {
        public Rect Rect { get; set; }
        public Vector2 ScaleDiscription { get; private set; }

        private bool _isDown;

        private Vector2 _startDown;
        private Vector2 _startPosition;
        private Color _colorDefault;
        private Color _colorSelected;
        private Color _colorCurrent;
        private Color _colorBackgroundDefault;

        public event Action Selected;

        private Waypoint _waypoint;

        public TaskView(Vector2 startPosition)
        {
            Rect = Rect.GetRectNewPosition(startPosition);
            Rect = Rect.GetRectNewSize(new Vector2(150, 70)); 
            ScaleDiscription = new Vector2(150, 25); 
            _waypoint = new Waypoint(8){Position = new Vector2(Rect.position.x, Rect.position.y + (Rect.size.y - ScaleDiscription.y))};
        }

        private void ControlHelperOnMouseDown(Vector2 mousePosition)
        {
            _isDown = mousePosition.x > Rect.position.x && mousePosition.x < Rect.position.x + Rect.size.x 
                                                        && mousePosition.y > Rect.position.y 
                                                        && mousePosition.y < Rect.position.y + Rect.size.y;
            _startDown = mousePosition;
            _startPosition = Rect.position;
        }
        
        public void Update()
        {
            _colorDefault = new Color(0.2f, 0.2f, 0.2f, 0.7f);
            _colorBackgroundDefault = new Color(0.2f, 0.2f, 0.2f, 0.9f);
            _colorSelected = new Color(0.34f, 0.34f, 0.35f, 0.7f);

            EditorGUI.DrawRect(Rect, _colorCurrent);
            EditorGUI.DrawRect(new Rect(_waypoint.Position, ScaleDiscription), _colorBackgroundDefault);
            
            GUIStyle styleLabel = GUI.skin.label;
            styleLabel.alignment = TextAnchor.MiddleCenter;
            GUI.Label(Rect, "TaskView", styleLabel);

            var image = EditorGUIUtility.IconContent("d_PreMatQuad@2x").image;
            var scaleTexture = new Vector2(15, 15);
            var positionUp = new Vector2(Rect.position.x + Rect.size.x / 2 - scaleTexture.x / 2, Rect.position.y - scaleTexture.y / 2);

            GUI.DrawTexture( new Rect(positionUp, scaleTexture), image);

            if (_isDown)
            {
              //  Move(InputEvents.MousePosition);
                Select();
            }
            else
            {
                Deselect();
            }
        }

        private Vector2 RectZone = new Vector2(700, 900);
        
        public void Move(Vector2 deltaPosition)
        {
            var positionAll = deltaPosition - (_startDown - _startPosition);
            var clampX = Mathf.Clamp(positionAll.x, 0, RectZone.x);
            //var clampY = Mathf.Clamp(positionAll.y, 0, RectZone.y);
            Rect.GetRectNewPosition(new Vector2(clampX, positionAll.y));
        }

        public void Select()
        {
            _colorCurrent = _colorSelected;
        }
        
        public void Deselect()
        {
            _colorCurrent = _colorDefault;
        }

        public IEnumerable<Waypoint> GetWaypoints()
        {
            return new[] { _waypoint };
        }

    }

    public interface IUpdatable
    {
        void Update();
    }
}