using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{
    
    private GameObject Player;
    [SerializeField] private float damage = 5f;
    [SerializeField] float bulletSpeed = 10;
    private float timer;
    [SerializeField] float bulletLifeTime = 10;
    private Rigidbody2D rb;
    [SerializeField] private AudioClip bangAudioClip;
    private GameObject bullet;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
      Player = GameObject.FindGameObjectWithTag("Player");
      Vector3 direction = Player.transform.position - transform.position;   
      rb.linearVelocity = direction.normalized * bulletSpeed; 
      
      float rota = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.Euler(0f, 0f, rota);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= bulletLifeTime)
        {
            Destroy(this.gameObject);
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDMG(damage);
            Destroy(this.gameObject);   
        }
    }
}
