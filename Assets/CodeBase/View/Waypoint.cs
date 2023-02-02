using UnityEngine;

namespace CodeBase.View
{
    public class Waypoint
    {
        public int DeltaSize { get; }
        public Vector2 Position { get; set; }
        public bool IsConnecting { get; set; }
        
        
        public Waypoint(int deltaSize)
        {
            DeltaSize = deltaSize;
        }
    }
}