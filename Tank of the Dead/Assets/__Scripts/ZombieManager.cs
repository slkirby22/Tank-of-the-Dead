using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    public static ZombieManager Instance;
    public int maxZombies = 200;
    private int currentZombieCount = 0;

    void Awake()
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

    public void IncrementZombieCount()
    {
        currentZombieCount++;
    }

    public void DecrementZombieCount()
    {
        currentZombieCount--;
    }

    public bool CanSpawnZombie()
    {
        return currentZombieCount < maxZombies;
    }
}
