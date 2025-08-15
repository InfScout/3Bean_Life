using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private GameObject MusicManager;
    public float _health;
    public HealthBar healthBar;
    
    void Start()
    {
        _health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Q"))
        {
            TakeDMG(5);
        }
    }

    public void TakeDMG(float dmg)
    {
            _health -= dmg;
            healthBar.SetHealth(_health);
        
            if (_health <= 0)
            {
                //die
            }
            else if (_health < maxHealth * .25f)
            {
                MusicManager.GetComponent<pitchController>().UpdatePitch(.75f);
            }
            else if (_health < maxHealth * .35f)
            {
                MusicManager.GetComponent<pitchController>().UpdatePitch(.8f);
            }
            else if (_health < maxHealth * .5f)
            {
                MusicManager.GetComponent<pitchController>().UpdatePitch(.9f);
            }
            else
            {
                MusicManager.GetComponent<pitchController>().UpdatePitch(1f);      
            }
    }
}
