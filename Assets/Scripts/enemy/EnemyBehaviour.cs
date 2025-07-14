using System;
using System.Collections;
using UnityEngine;

public enum EnemyAiState
{
    Chase,
    Patrol,
    Attack
}
public class EnemyBehaviour : MonoBehaviour
{
    
    [SerializeField]private float moveSpeed;
    [SerializeField]private Transform target;
    [SerializeField]private float minDistance;
    [SerializeField]private float maxDistance;
    
    [SerializeField]private float patrolSpeed;
    [SerializeField]private Transform[] patrolPoint;
    [SerializeField]private float waitTime;
    private int currentPointIndex;

    private bool once;
    
    
    [SerializeField] EnemyAiState CurrentState = EnemyAiState.Patrol;

    private void Update()
    {
    
        switch (CurrentState)
        {
        
            case EnemyAiState.Patrol:
                PatrolState();
                break;
        
            case EnemyAiState.Chase:
                ChaseTarget();
                break;
        
            case EnemyAiState.Attack:

                break;
        }
    }
    /// <summary>
    /// Chase state
    /// </summary>
    private void ChaseTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// patrol state
    /// </summary>
    private void PatrolState()
    {
        if (transform.position != patrolPoint[currentPointIndex].position)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                patrolPoint[currentPointIndex].position,
                patrolSpeed * Time.deltaTime);
        }
        else
        {
            if (once == false)
            {
                once = true;
                StartCoroutine(Wait());
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        if (currentPointIndex + 1 < patrolPoint.Length)
        {
            currentPointIndex++;
        }
        else
        {
            currentPointIndex = 0;
        }
        once = false;
    }

}