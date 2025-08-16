using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private GameObject MusicManager;
    public float _health;
    [SerializeField] private Bars healthbar;
    [SerializeField] private GameObject youDied;
    [SerializeField]private GameObject GameManeger;
    [SerializeField]private float healAmmount = 25f;
    [SerializeField] private int maxPots = 3;
    [SerializeField] private int healPots = 3;
    [SerializeField]private AudioClip healSound;
    void Start()
    {
        _health = maxHealth;
        healthbar.SetMaxBar(maxHealth);
        
    }

    public void HealKey(InputAction.CallbackContext context)
    {
        if (healPots > 0)
        {
            Heal(healAmmount);
        }
    }

    public void Heal(float healAmmount)
    {
        _health += healAmmount;
        healthbar.SetBar(_health);
    }

    public void TakeDMG(float dmg)
    {
            _health -= dmg;
            healthbar.SetBar(_health);
        
            if (_health == 0)
            {
                
                StartCoroutine(deathHappens());

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

    IEnumerator deathHappens()
    {
        youDied.SetActive(true);
        MusicManager.GetComponent<pitchController>().MuteAudio();
        GameManeger.GetComponent<SaveMan>().Load();
        yield return new WaitForSeconds(3f);
        youDied.SetActive(false);
    }
}
