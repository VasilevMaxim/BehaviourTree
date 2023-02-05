using CodeBase.View;
using UnityEngine;

public interface UIElement : IUpdatable
{
    Rect Rect { get; set; }
}