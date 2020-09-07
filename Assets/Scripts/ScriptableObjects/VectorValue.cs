using UnityEngine;

public enum World
{
    Overworld,
    Underworld,
    Dungeon
}

[CreateAssetMenu(fileName = "VectorValue", menuName = "MyZelda/VectorValue", order = 0)]
public class VectorValue : ScriptableObject 
{
    public Vector3 initValue;
    public World savedWorldPosition;
}