using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbleController : MonoBehaviour
{
    [SerializeField] private int shotsToDestroy = 3;
    [SerializeField] private bool isDestructable = true;

    private int currentShots = 0;

    [SerializeField] private GameObject zombiePrefab;

    [SerializeField] private string projectileComponentName = "Bullet_Nav_CS";

    public ZombieSpawner zombieSpawner;

    void Start()
    {
        zombieSpawner = GetComponent<ZombieSpawner>();
    }

    private void OnEnable()
    {
        currentShots = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent(projectileComponentName) != null)
        {
            RegisterShot();
        }
    }

    public void RegisterShot()
    {
        currentShots++;

        if (currentShots >= shotsToDestroy && isDestructable == true)
        {
            DestroyRubble();
            StopZombieSpawn();
        }
    }

    private void DestroyRubble()
    {
        Destroy(gameObject);
        zombieSpawner.SpawnZombie();
    }

    private void StopZombieSpawn()
    {
        if (zombieSpawner != null)
        {
            zombieSpawner.StopSpawning();
        }
    }
}
