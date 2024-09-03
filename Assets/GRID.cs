using UnityEngine;
public class Grid : MonoBehaviour
{
    public float cellSize = 1f; // Размер клетки

    public Vector3 GetSnappedPosition(Vector3 originalPosition)
    {
        float x = Mathf.Round(originalPosition.x / cellSize) * cellSize;
        float y = Mathf.Round(originalPosition.y / cellSize) * cellSize;
        return new Vector3(x, y, originalPosition.z);
    }
}