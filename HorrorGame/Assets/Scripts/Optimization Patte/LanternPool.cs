using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LanternPool : MonoBehaviour
{
    public static LanternPool Instance;
    public GameObject lanternPrefab;
    private GameObject[] lanterns;
    private int currentIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void InitializePool(int poolSize)
    {
        lanterns = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            lanterns[i] = Instantiate(lanternPrefab);
            lanterns[i].SetActive(false);
        }
    }

    public GameObject GetLantern()
    {
        GameObject lantern = lanterns[currentIndex];
        currentIndex = (currentIndex + 1) % lanterns.Length;
        return lantern;
    }
}