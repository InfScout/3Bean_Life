
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using Unity.VisualScripting;
   using UnityEngine;
   using UnityEngine.Events;
   using Random = UnityEngine.Random;


   public class Health : MonoBehaviour
   {
       [SerializeField] private float currentHealth, maxHealth;
       [SerializeField] private GameObject _particleEffect;
       public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;
       
       [SerializeField] private float _splooshDuration;
       
       [SerializeField] private AudioClip _hitSound;
       
       private bool isDead = false;

       private void Awake()
       {
           currentHealth = maxHealth;
       }

       public void InitializeHealth(int healthValue)
       {
           currentHealth = healthValue;
           maxHealth = healthValue;
           isDead = false;
       }
    
       public void GetHit(float amount, GameObject sender)
       {
           if (isDead)
               return;
           if (sender.layer == gameObject.layer)
               return;
   
           currentHealth -= amount;
           if (currentHealth > 0)
           {
               AudioMan.instance.PlaySound(_hitSound, transform, 1f, Random.Range(0.8f, 1.2f));
                StartCoroutine(Sploosh());
               OnHitWithReference?.Invoke(sender);
           }
           else
           {
               OnDeathWithReference?.Invoke(sender);
               isDead = true;
               Destroy(gameObject);
           }
           
           
       }

       private IEnumerator Sploosh()
       {
           GameObject particleEffect = Instantiate(_particleEffect, transform.position, Quaternion.identity);
           yield return new WaitForSeconds(_splooshDuration);
           Destroy(particleEffect);
       }
   }

