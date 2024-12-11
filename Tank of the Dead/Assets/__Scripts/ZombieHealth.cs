using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    //[Header("Inscribed")]
    //public int zombieHealth = 2;

    private int zombieDamage;
    public ZombieManager zombieManager;

    void Start()
    {
        zombieManager = GameObject.Find("Game_Controller").GetComponent<ZombieManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie")) ;
        else if (collision.gameObject.CompareTag("Rubble")) ;
        else
        {
            zombieDamage++;

            if (zombieDamage >= zombieManager.zombieHealth)
            {
                ZombieDie();
            }
        }
    }

    private void ZombieDie()
    {
        Destroy(gameObject);

        zombieManager.DecrementZombieCount();
    }
}
