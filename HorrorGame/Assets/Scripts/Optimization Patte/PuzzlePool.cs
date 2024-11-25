using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A pool of objects related to the puzzle
/// </summary>
public class PuzzlePool : MonoBehaviour
{
    List<Item> itemsToUse = new List<Item>();
    ItemFactory itemFactory = new ItemFactory();
    
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private GameObject itemPrefab2;
    
    public Dictionary<string, GameObject> itemPool = new Dictionary<string, GameObject>();
    
    void Awake()
    {
        itemFactory = new ItemFactory();

        // Example: Retrieve shared items
        Item sword = itemFactory.GetItem("Sword", itemPrefab, "A sharp blade.");
        Item potion = itemFactory.GetItem("Potion", itemPrefab2, "Restores health.");
        
        itemsToUse.Add(sword);
        itemsToUse.Add(potion);
        
        Destroy(sword.gameObject);
        Destroy(potion.gameObject);
        
        //Pre instantiates the items 
        foreach (Item item in itemsToUse)
        {
            Debug.Log("Adding item: " + item.GetItemName());
            GameObject obj = Instantiate(item.GetItemPrefab());
            itemPool.Add(item.GetItemName(), obj);
            obj.SetActive(false);
        }
    }


    public GameObject GetPuzzleItem(string name)
    {
        if (itemPool.ContainsKey(name))
        {
            return itemPool[name];
        }
        else
        {
            return null;
        }
    }
}
