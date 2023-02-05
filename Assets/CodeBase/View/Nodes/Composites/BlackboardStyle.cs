using UnityEngine;

[CreateAssetMenu(fileName = "NodeStyle", menuName = "ScriptableObjects/BlackboardStyle")]
public class BlackboardStyle : ScriptableObject
{
    [field: SerializeField] public Vector2 Scale { get; private set; }
    [field: SerializeField] public Color ColorDefault { get; private set; }
}