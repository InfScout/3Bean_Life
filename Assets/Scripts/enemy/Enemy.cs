using System;
using System.Collections;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField]private EnemyStats stats;
    [SerializeField]private float _health;

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
