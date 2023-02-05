using UnityEngine;

namespace CodeBase.View
{
    public static class Vector2Extensions
    {
        public static bool IsHoverRect(this Vector2 vector2, Rect rect)
        {
            return vector2.x > rect.x
                   && vector2.x < rect.x + rect.width
                   && vector2.y > rect.y
                   && vector2.y < rect.y + rect.height;
        }

        public static bool IsRange(this float value, float min, float max)
        {
            return value >= min && value <= max;
        }

    }
}