using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyStats stats;
    [SerializeField] private float _health;
    [SerializeField] private float _splooshDuration;

    [SerializeField] private GameObject _particleEffect;
    
    private bool IsDead() => _health <= 0;
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

    private IEnumerator SplooshDuration()
    {
        GameObject particles = Instantiate(_particleEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(_splooshDuration);
        Destroy(particles);
    }
}
