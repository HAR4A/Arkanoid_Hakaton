using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public string levelName; // Имя уровня (можно использовать как номер)
    public GameObject brickPrefab; // Префаб кирпичиков
    public int numberOfBricks; // Количество кирпичиков (опционально)
}