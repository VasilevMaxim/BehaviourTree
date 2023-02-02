using CodeBase.View;
using UnityEngine;

public interface UIElement : IUpdatable
{
    Vector2 Position { get; set; }
    Vector2 Scale { get; }
}