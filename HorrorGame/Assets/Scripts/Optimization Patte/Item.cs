using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] string itemName;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] private string description;

    public void Initialize(string name, GameObject prefab, string desc)
    {
        itemName = name;
        itemPrefab = prefab;
        description = desc;
    }

    public void SpawnItem(Vector3 pos)
    {
        var item = Instantiate(itemPrefab, pos, Quaternion.identity);
    }

    public string GetItemName()
    {
        return itemName;
    }

    public GameObject GetItemPrefab()
    {
        return itemPrefab;
    }

    public string GetItemDescription()
    {
        return description;
    }
}
