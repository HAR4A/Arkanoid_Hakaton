using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]

public class LevelData : ScriptableObject
{
    public GameObject brickPrefab;
    public int levelNumber;
    public Vector2[] brickPositions;
}