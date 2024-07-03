using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public Transform[] PatrolPoints;
    public int targetIndex;
    public float Patrolspeed;
    public float chaseSpeed = 5f;
    public float viewRange = 10f;
    public float catchDistance = 1.5f;
    public LayerMask obstacleMask;

    private bool isPatrollingForward = true;
    private bool isChasing;
    private Transform player;
    

    private void Start()
    {
        targetIndex = 0;
        isChasing = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }

        CheckForPlayer();
    }

    private void nextTargetIndex()
    {
        //loop - circle
        //targetIndex = (targetIndex + 1) % PatrolPoints.Length;
        
        //line - back and forward
        if (isPatrollingForward)
        {
            targetIndex++;
            if (targetIndex >= PatrolPoints.Length)
            {
                targetIndex = PatrolPoints.Length - 1;
                isPatrollingForward = false;
            }
        }
        else
        {
            targetIndex--;
            if (targetIndex < 0)
            {
                targetIndex = 0;
                isPatrollingForward = true;
            }
        }
    }

    private void Patrol()
    {
        if (PatrolPoints.Length == 0)
            return;

        Vector3 target = PatrolPoints[targetIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, target, Patrolspeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.2f)
        {
            nextTargetIndex();
        }
    }
    
    private void CheckForPlayer()
    {
        if (Vector3.Distance(transform.position, player.position) <= viewRange)
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            Ray ray = new Ray(transform.position, directionToPlayer);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, viewRange, ~obstacleMask))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    isChasing = true;
                }
            }
        }
        else
        {
            isChasing = false;
        }
    }
    
    private void ChasePlayer()
    {
        Vector3 playerPos = player.position;
        playerPos.y = transform.position.y;
        transform.position = Vector3.MoveTowards(transform.position, playerPos, chaseSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, player.position) <= catchDistance)
        {
            GameOver();
            isChasing = false;
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}
