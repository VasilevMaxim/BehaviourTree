using System.Collections.Generic;
using CodeBase.View;
using UnityEditor;
using UnityEngine;

public class WaypointsDrawer
{
    public List<Waypoint> Waypoints { get; private set; }

    private int _count;
    
    private Vector2 _positionUp;
    private Vector2 _positionDown;
    private Vector2 _positionRight;
    private Vector2 _positionLeft;

    private Vector2 _scaleSelectZone;
    
    public WaypointsDrawer(int count)
    {
        _count = count;
        _scaleSelectZone = new Vector2(15, 15);
    }

    public void Move(Vector2 scale, Vector2 position)
    {
        if (_count == 4)
        {
            _positionUp = new Vector2(position.x + scale.x / 2 - _scaleSelectZone.x / 2, position.y - _scaleSelectZone.y / 2);
            _positionDown = new Vector2(position.x + scale.x / 2 - _scaleSelectZone.x / 2, position.y + scale.y - _scaleSelectZone.y / 2);
            _positionRight = new Vector2(position.x + scale.x - _scaleSelectZone.x / 2, position.y + scale.y / 2 - _scaleSelectZone.y / 2);
            _positionLeft = new Vector2(position.x - _scaleSelectZone.x / 2, position.y + scale.y / 2 - _scaleSelectZone.y / 2);
            
            Waypoints = new List<Waypoint>
            {
                new(20) { Position = _positionUp },
                new(20) { Position = _positionDown },
                new(20) { Position = _positionRight },
                new(20) { Position = _positionLeft }
            };
            
            Waypoints[0].Position = _positionUp + _scaleSelectZone / 2;
            Waypoints[1].Position = _positionDown + _scaleSelectZone / 2;
            Waypoints[2].Position = _positionRight + _scaleSelectZone / 2;
            Waypoints[3].Position = _positionLeft + _scaleSelectZone / 2;
            
            
            var image = EditorGUIUtility.IconContent("d_PreMatQuad@2x").image;
            
            GUI.DrawTexture( new Rect(_positionUp, _scaleSelectZone), image);
            GUI.DrawTexture( new Rect(_positionDown, _scaleSelectZone), image);
            GUI.DrawTexture( new Rect(_positionRight, _scaleSelectZone), image);
            GUI.DrawTexture( new Rect(_positionLeft, _scaleSelectZone), image);
        }
    }
}