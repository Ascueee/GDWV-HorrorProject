using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public PuzzlePool puzzlePool;
    void Start()
    {
        GameObject swordFromPool = Instantiate(puzzlePool.GetPuzzleItem("Sword"), new Vector3(3, 0, 0), Quaternion.identity);
        GameObject potionFromPool = Instantiate(puzzlePool.GetPuzzleItem("Potion"), new Vector3(4, 0, 0), Quaternion.identity);
        
        swordFromPool.SetActive(true);
        potionFromPool.SetActive(true);
    }
}
