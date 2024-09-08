using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    private GameObject _currentInstance;  
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;  
    }

    private void Update()
    {
        if (_currentInstance != null)
        {
            UpdatePrefabPosition(); //привязка префаба к курсору
            
            if (Input.GetMouseButtonDown(0))
            {
                PlacePrefab();
            }

            else if (Input.GetMouseButtonUp(1))
            {
                Destroy(_currentInstance);
            }

            else if (Input.mouseScrollDelta.y != 0)
            {
                _currentInstance.transform.Rotate(0, 0, Input.mouseScrollDelta.y * 10f);
            }
        }
    }

    public void StartPlacingPrefab(GameObject prefabToPlace)
    {
        if (prefabToPlace != null && _currentInstance == null)
        {
            _currentInstance = Instantiate(prefabToPlace);
        }
    }

    private void UpdatePrefabPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(_mainCamera.transform.position.z);

        Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(mousePosition);

        //границы префаба
        Bounds prefabBounds = GetPrefabBounds(_currentInstance);

        //границы экрана
        float leftBoundary = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, _mainCamera.transform.position.z)).x;
        float rightBoundary = _mainCamera.ViewportToWorldPoint(new Vector3(1, 0, _mainCamera.transform.position.z)).x;
        float topBoundary = _mainCamera.ViewportToWorldPoint(new Vector3(0, 1, _mainCamera.transform.position.z)).y;
        float bottomBoundary = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, _mainCamera.transform.position.z)).y;

        //ограничение положения префаба
        float clampedX = Mathf.Clamp(worldPosition.x, leftBoundary + prefabBounds.extents.x, rightBoundary - prefabBounds.extents.x);
        float clampedY = Mathf.Clamp(worldPosition.y, bottomBoundary + prefabBounds.extents.y, topBoundary - prefabBounds.extents.y);

        _currentInstance.transform.position = new Vector3(clampedX, clampedY, worldPosition.z);
    }
    
    private Bounds GetPrefabBounds(GameObject prefab)
    {
        Bounds bounds = new Bounds(prefab.transform.position, Vector3.zero);
    
        //проверка дочерних
        foreach (var renderer in prefab.GetComponentsInChildren<Renderer>())
        {
             bounds.Encapsulate(renderer.bounds);
        }

        foreach (var collider in prefab.GetComponentsInChildren<Collider2D>())
        {
          bounds.Encapsulate(collider.bounds);
        }
    
        return bounds;
    }
    
    private void PlacePrefab()
    {
        _currentInstance = null;
    }
}