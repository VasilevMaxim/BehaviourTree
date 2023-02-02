using UnityEngine;

namespace CodeBase.View
{
    public interface IDrawerLink
    {
        void Draw(params Vector3[] points);
    }
}