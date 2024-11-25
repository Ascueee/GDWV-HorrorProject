using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    private void Start()
    {
        LanternPool.Instance.InitializePool(spawnPoints.Length);
        SpawnLanterns();
    }

    private void SpawnLanterns()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            GameObject lantern = LanternPool.Instance.GetLantern();
            if (lantern != null)
            {
                lantern.transform.position = spawnPoint.position;
                lantern.SetActive(true);
            }
        }
    }
}