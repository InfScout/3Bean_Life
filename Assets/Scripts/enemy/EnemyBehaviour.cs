using System;
using System.Collections;
using UnityEngine;
using Pathfinding;
using Random = System.Random;

public enum EnemyAiState
{
    Chase,
    Patrol,
    PreAttack,
    Attack
}
public class EnemyBehaviour : MonoBehaviour
{
    
    private Animator _animator;
    
    IAstarAI ai;
    [Header("Chase")]
    [SerializeField]private Transform target;
    
   [Header("Patrol")]
    [SerializeField]private Transform[] patrolPoint;
    [SerializeField]private float waitTime;
    private int currentPatrolPoint;
    float switchTime = float.PositiveInfinity;
    
    [Header("detection")]
    private bool seePlayer = false;
    [SerializeField]private float detectionRange;
    [SerializeField]private Vector2 playerDirection;
    private Transform player;

    [SerializeField] private EnemyAiState CurrentState;
    
    [Header("Attack")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate = 1.5f;
    [SerializeField] private float attackDist = 5;
    
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        EnemyAiState CurrentState = EnemyAiState.Patrol;
    }
    private void OnEnable()
    {
        ai = GetComponent<IAstarAI>();
        if (ai != null) ai.onSearchPath += Update;
        _animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        if (ai != null) ai.onSearchPath -= Update;
    }

    private void Update()
    {
    
        DetectPlayer();
        
        switch (CurrentState)
        {
        
            case EnemyAiState.Patrol:
                PatrolState();
                break;
        
            case EnemyAiState.Chase:
                ChaseTarget();
                break;
        
            case EnemyAiState.PreAttack:
                PreAttack();
                break;
            case EnemyAiState.Attack:
                Attack();
                break;
        }
    }
    
    private void ChaseTarget()
    {
        if (target != null && ai != null) ai.destination = target.position;
    }
    
    private void PatrolState()
    {
        if (patrolPoint.Length == 0) return;

        bool search = false;

        
        if (ai.reachedEndOfPath && !ai.pathPending && float.IsPositiveInfinity(switchTime)) {
            switchTime = Time.time + waitTime;
        }

        if (Time.time >= switchTime) {
            currentPatrolPoint = currentPatrolPoint + 1;
            search = true;
            switchTime = float.PositiveInfinity;
        }

        currentPatrolPoint = currentPatrolPoint % patrolPoint.Length;
        ai.destination = patrolPoint[currentPatrolPoint].position;

        if (search) ai.SearchPath();
    }

    private void PreAttack()
    {
        //play animation
        _animator.SetBool("isAttak",true);
      
        StartCoroutine(WaitToAttack());
    }

    public void Attack()
    {
        Debug.Log("attack");

        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        
        Debug.Log("chase");
        CurrentState = EnemyAiState.Chase;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EnemyAiState CurrentState = EnemyAiState.Chase;
            target = other.transform;
        }
    }

    private void DetectPlayer()
    {
        Vector2 enemyToPlayer = player.position - transform.position;
        playerDirection = enemyToPlayer.normalized;
        if (enemyToPlayer.magnitude <= attackDist)
        {
            CurrentState = EnemyAiState.PreAttack;
        }
        else if (enemyToPlayer.magnitude <= detectionRange)
        {
            CurrentState = EnemyAiState.Chase;
        }
        
        else
        {
            CurrentState = EnemyAiState.Patrol;
        }
    }

    IEnumerator WaitToAttack()
    {
        yield return new WaitForSeconds(fireRate);
        CurrentState = EnemyAiState.Attack;
    }
   
    
}

   

