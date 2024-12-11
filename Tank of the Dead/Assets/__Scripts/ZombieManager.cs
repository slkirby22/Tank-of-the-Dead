using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieManager : MonoBehaviour
{
    public static ZombieManager Instance;
    
    [Header("Inscribed")]
    public int zombieHealth = 2;
    public int maxZombies = 200;

    private int currentZombieCount = 0;
    private int nextRoundCounter = 0;

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

    public void FixedUpdate()
    {
        if (currentZombieCount == 0)
        {
            nextRoundCounter++;
        }
        else
        {
            nextRoundCounter = 0;
        }

        if (nextRoundCounter >= 100)
        {
            Debug.Log("Next Round");
            roundLoader();
            nextRoundCounter = 0;
        }
    }

    public void roundLoader()
    {
        switch(SceneManager.GetActiveScene().name)
        {
            case "Infinite":
                SceneManager.LoadScene("Main");
                break;
            case "Town lvl 1":
                SceneManager.LoadScene("Town lvl 2");
                break;
            case "Town lvl 2":
                SceneManager.LoadScene("Town lvl 3");
                break;
            case "Town lvl 3":
                SceneManager.LoadScene("Main");
                break;
        }
    }
}
