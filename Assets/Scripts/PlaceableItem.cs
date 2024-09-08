using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "NewPlaceableItem", menuName = "Placeable Item", order = 1)]
public class PlaceableItem : ScriptableObject
{
    public GameObject prefab;  
}