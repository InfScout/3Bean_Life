using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
                                                                                               
    [Header("Stats")]
    
    [SerializeField] private float healthMax = 100f;
    [SerializeField] private float maxStamina = 100f;
    [SerializeField] private float staminaRegenerationRate = 0.5f;

    [SerializeField]private float stamina;
    private float _health;
    
    [Header("movement")]
    
    [SerializeField] private float baseSpeed = 5f;
    [SerializeField] private float dashSpeed = 100f;
    [SerializeField] private float dashStaminaUse = 1f;
    [SerializeField] private float dashDuration = 1f;
    [SerializeField] private float dashCooldown = 0.5f;
    
    private bool _canDash = true;
    private bool _dashing = false;
    private Rigidbody2D _rb;
    private Vector2 _movement;
    private Vector2 _dashDir;
    private Animator _animator;
    
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        _canDash = true;
        stamina = maxStamina;
        _health = healthMax;
    }

    void Update()
    {
        if (_dashing)
        {
            return;
        }
        stamina += Time.deltaTime * staminaRegenerationRate;
        stamina = Mathf.Clamp(stamina, 0, maxStamina);
        _rb.linearVelocity = _movement * baseSpeed;
        if (Input.GetKeyDown(KeyCode.LeftShift) && _canDash && stamina >= dashStaminaUse)
        {
        StartCoroutine(Dash());
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        _animator.SetBool("isWalking", true);
        if (context.canceled)
        {
            _animator.SetBool("isWalking", false);
            _animator.SetFloat("lastInputX", _movement.x);
            _animator.SetFloat("lastInputY", _movement.y);
        }
        
        _movement = context.ReadValue<Vector2>();
        _animator.SetFloat("CurrentX", _movement.x);
        _animator.SetFloat("CurrentY", _movement.y);
    }

    private IEnumerator Dash()
    { 
        _canDash = false;
        _dashing = true;
        stamina -= dashStaminaUse;
        _rb.linearVelocity = new Vector2(_movement.x * dashSpeed, _movement.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        _dashing = false;
        
        yield return new WaitForSeconds(dashCooldown);
        _canDash = true;
    }
}