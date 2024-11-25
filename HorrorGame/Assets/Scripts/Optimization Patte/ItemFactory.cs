using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    private Dictionary<string, Item> itemPool = new Dictionary<string, Item>();

    public Item GetItem(string itemName, GameObject prefab, string description)
    {
        if (!itemPool.ContainsKey(itemName))
        {
            // Create a new Item and add it to the pool if it doesn't exist
            GameObject newItemObject = new GameObject(itemName);
            Item newItem = newItemObject.AddComponent<Item>();
            newItem.Initialize(itemName, prefab, description);
            itemPool[itemName] = newItem;
        }

        return itemPool[itemName];
    }
}
