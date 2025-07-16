using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class Enemy : MonoBehaviour
{
    [SerializeField]private EnemyStats stats;
    [SerializeField]private float _health;

    public UnityEvent<GameObject> OnHitRef;
    
    private bool _isDead;
    private void Awake()
    {
        _health = stats.maxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
   

}
