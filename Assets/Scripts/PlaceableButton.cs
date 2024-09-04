using UnityEngine;
using UnityEngine.UI;

public class PlaceableButton : MonoBehaviour
{
    public PlaceableItem _item;
    private PlacementManager placementManager;

    private void Start()
    {
        placementManager = FindObjectOfType<PlacementManager>();
        
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        placementManager.StartPlacingPrefab(_item.prefab);
    }
}