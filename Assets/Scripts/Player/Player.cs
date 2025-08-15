using UnityEngine;

public class Player : MonoBehaviour , IHittable
{
    [SerializeField]
    private float maxHealth = 100f;

    public float _health;
    public HealthBar healthBar;
    
    void Start()
    {
        _health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    
    public bool isHittable()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDMG(float dmg)
    {
        if (_health <= 0)
        {
            //die
        }
        else
        {
            _health -= dmg;
            healthBar.SetHealth(_health);
        }
    }
}
