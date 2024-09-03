using UnityEngine;

public class FigurePlacer : MonoBehaviour
{
    public GameObject[] figurePrefabs; // массив Prefab'ов фигур
    private GameObject currentFigure;  // текущая активная фигура
    private bool isPlacing = false;    // флаг, находится ли игрок в режиме размещения
    private Grid grid; // Добавьте это поле
 
    void Start()
    {
        grid = FindObjectOfType<Grid>(); // Найдите объект Grid в сцене
    }
    
    
    void Update()
    {
        if (isPlacing && currentFigure != null)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 snappedPosition = grid.GetSnappedPosition(mousePosition); // Используем привязку
            currentFigure.transform.position = snappedPosition;

            if (Input.GetMouseButtonDown(0))
            {
                isPlacing = false;
                currentFigure = null;
            }
        }
    }

    public void StartPlacingFigure(int figureIndex)
    {
        if (figureIndex >= 0 && figureIndex < figurePrefabs.Length)
        {
            currentFigure = Instantiate(figurePrefabs[figureIndex]);
            isPlacing = true;
        }
    }
}