using UnityEngine;

[CreateAssetMenu(fileName = "NodeStyle", menuName = "ScriptableObjects/NodeStyle")]
public class NodeStyle : ScriptableObject
{
    [field: SerializeField] public Vector2 Scale { get; private set; }

    [field: SerializeField] public Color ColorDefault { get; private set; }
    [field: SerializeField] public Color ColorSelected { get; private set; }
    [field: SerializeField] public Color ColorHover { get; private set; }
}