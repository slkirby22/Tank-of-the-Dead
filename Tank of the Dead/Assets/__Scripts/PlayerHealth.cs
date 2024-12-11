using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 100;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            playerHealth--;
        }
        else if (collision.gameObject.CompareTag("Water"))
        {
            playerHealth = 0;
        }

        if (playerHealth <= 0)
        {
            PlayerDie();
        }
    }

    public void PlayerDie()
    {
        Debug.Log("You Died!");

        returnToMainMenu();
    }

    private void returnToMainMenu()
    {
        Debug.Log("Restarting...");
        SceneManager.LoadScene("Main");
    }
}
