using System;
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

    public static Rect Clip(this Rect rect, Rect rectClip, int sizeObstacle)
    {
        var positionXClamp = rect.x;
        var positionYClamp = rect.y;
        
        var halfObstacle = sizeObstacle / 2;
        rectClip = new Rect(rectClip.x - halfObstacle, rectClip.y - halfObstacle, rectClip.width + sizeObstacle, rectClip.height + sizeObstacle);

        var halfWidth = rect.width / 2;
        var isRangeX = rect.xMax.IsRange(rectClip.xMin, rectClip.xMax) || rect.xMin.IsRange(rectClip.xMin, rectClip.xMax);
        var isRangeY = rect.yMax.IsRange(rectClip.yMin, rectClip.yMax) || rect.yMin.IsRange(rectClip.yMin, rectClip.yMax);
        
        if (Math.Abs(rectClip.xMin - rect.xMax) < halfWidth && isRangeY == true)
        { 
            positionXClamp = Mathf.Clamp(rect.x, float.NegativeInfinity, rectClip.x - rect.width);
        }
        else if (Math.Abs(rectClip.xMax - rect.xMin) < halfWidth && isRangeY == true)
        {
            positionXClamp = Mathf.Clamp(positionXClamp, rectClip.max.x, float.PositiveInfinity);
        }
        
        else if (Math.Abs(rect.yMax - rectClip.yMin) < rect.height && isRangeX)
        {
            positionYClamp = Mathf.Clamp(rect.y, float.NegativeInfinity, rectClip.min.y - rect.height);
        }
        
        else if (Math.Abs(rect.yMin - rectClip.yMax) < rect.height && isRangeX)
        {
            positionYClamp = Mathf.Clamp(rect.y, rectClip.yMax, float.PositiveInfinity);
        }

        return new Rect(positionXClamp, positionYClamp, rect.width, rect.height);
    }
}