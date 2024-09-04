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
        _currentInstance.transform.position = worldPosition;
    }

    private void PlacePrefab()
    {
        _currentInstance = null;
    }
}