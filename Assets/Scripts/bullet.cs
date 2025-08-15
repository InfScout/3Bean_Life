using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{
    private IHittable _playerInHitbox = null;
    [SerializeField] private float damage = 5f;
    [SerializeField] float bulletSpeed = 10;
    [SerializeField] float bulletLifeTime = 10;
    private Rigidbody2D _rigidbody;
    [SerializeField] private AudioClip bangAudioClip;
    private GameObject bullet;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        AudioMan.instance.PlaySound(bangAudioClip, transform, 10f, Random.Range(.5f, 10f));
    }

    public void Launch(Vector2 dir)
    {
        _rigidbody.AddForce(dir * bulletSpeed);
        Destroy(gameObject, bulletLifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IHittable hittable) && hittable.isHittable())
        {
            _playerInHitbox.TakeDMG(damage);

        }
    }
}
