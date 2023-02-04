using CodeBase.View;
using UnityEngine;

public static class RectExtensions
{
    public static Rect GetRectNewPosition(this Rect rect, Vector2 position)
    {
        return new Rect(position, rect.size);
    }
    
    public static Rect GetRectNewSize(this Rect rect, Vector2 size)
    {
        return new Rect(rect.position, size);
    }
}

public interface UIElement : IUpdatable
{
    Rect Rect { get; set; }
}