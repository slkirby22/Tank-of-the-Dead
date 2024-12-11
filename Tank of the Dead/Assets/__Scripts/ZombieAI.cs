using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public GameObject player;
    public float detectionRange = 200f;
    public float attackRange = 2f;

    private NavMeshAgent Agent;
    private Vector3 previousPlayerPosition;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();

        if (player == null)
        {
            GameObject tankPlayer = GameObject.Find("SD_Firefly_2.0_Player");

            if (tankPlayer != null)
            {
                player = tankPlayer.transform.Find("MainBody").gameObject;
            }
            else
            {
                Debug.LogError("SD_Firefly_2.0_Player not found");
            }
        }
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= detectionRange)
            {
                if (Vector3.Distance(previousPlayerPosition, player.transform.position) > 1f)
                {
                    Agent.SetDestination(player.transform.position);
                    previousPlayerPosition = player.transform.position;
                }
            }
        }
    }

    void AttackPlayer()
    {
        Debug.Log("Zombie is attacking the player");
    }
}
