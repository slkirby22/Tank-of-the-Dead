using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [Header("Inscribed")]
    public bool GameModeChoice;


    private void OnTriggerEnter(Collider other)
    {
        if (GameModeChoice == true)
        {
            Debug.Log("Start Infinite Mode");
            SceneManager.LoadScene("Infinite Round");
        }
        else if (GameModeChoice == false)
        {
            Debug.Log("Start Adventure Mode");
            SceneManager.LoadScene("Town lvl 1");
        }
    }
}