/*
using UnityEngine;

public class PlacementController : MonoBehaviour
{
    public GameObject prefabToPlace;  // Префаб, который нужно разместить
    private GameObject currentInstance;  // Текущая инстанция префаба (фигура, привязанная к курсору)
    private Camera mainCamera;  // Ссылка на основную камеру

    private void Start()
    {
        mainCamera = Camera.main;  // Инициализация основной камеры
    }

    private void Update()
    {
        if (currentInstance != null)
        {
            // Обновляем позицию префаба на курсоре
            UpdatePrefabPosition();

            // Проверяем нажатие ЛКМ для размещения объекта
            if (Input.GetMouseButtonDown(0))
            {
                PlacePrefab();
            }
        }
    }

    public void StartPlacingPrefab()
    {
        if (prefabToPlace != null)
        {
            // Создаем новый экземпляр префаба и привязываем его к курсору
            currentInstance = Instantiate(prefabToPlace);
        }
    }

    private void UpdatePrefabPosition()
    {
        // Получаем позицию курсора в мировых координатах
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(mainCamera.transform.position.z);  // Устанавливаем нужное значение z для камеры
        
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        currentInstance.transform.position = worldPosition;
    }

    private void PlacePrefab()
    {
        // Размещаем префаб на сцене (снимаем с курсора)
        currentInstance = null;
    }
}
*/