using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public float spawnInterval = 2f;
    public int zombiesPerSpawn = 2;
    public float spawnRadius = 1f;

    private bool isSpawning = true;
    private Transform rubbleTransform;

    void Start()
    {
        rubbleTransform = transform;

        StartCoroutine(SpawnZombies());
    }

    private IEnumerator SpawnZombies()
    {
        while (isSpawning)
        {
            for (int i = 0; i < zombiesPerSpawn; i++)
            {
                if (ZombieManager.Instance.CanSpawnZombie())
                {
                    SpawnZombie();
                }
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void SpawnZombie()
    {
        if (zombiePrefab != null && rubbleTransform != null)
        {
            Vector3 randomOffset = new Vector3
                (
                Random.Range(-spawnRadius, spawnRadius),
                0f,
                Random.Range(-spawnRadius, spawnRadius)
                );

            Vector3 spawnPosition = rubbleTransform.position + randomOffset;

            Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
            ZombieManager.Instance.IncrementZombieCount();
        }
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }

    public void StartSpawning()
    {
        isSpawning = true;
        StartCoroutine(SpawnZombies());
    }
}
