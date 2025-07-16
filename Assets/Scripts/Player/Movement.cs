
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("Misk")]
    [SerializeField] private GameObject Pov;
    
    [Header("Stats")]

    [SerializeField] private float healthMax = 100f;
    [SerializeField] private float maxStamina = 100f;
    [SerializeField] private float staminaRegenerationRate = 0.5f;
    [SerializeField]private float stamina;
    private float _health;
    
    [Header("movement")]

    [SerializeField] private float baseSpeed = 5f;
    private Rigidbody2D _rb;
    private Vector2 _movement;
    [SerializeField] private float dashSpeed = 100f;
    [SerializeField] private float dashStaminaUse = 1f;
    [SerializeField] private float dashDuration = 1f;
    [SerializeField] private float dashCooldown = 0.5f;
    
    [Header("Mouse")]
    [SerializeField] private InputActionReference pointerPosition;
    private Vector2 _pointerInput;
    private Vector2 MousePos;

    private WeaponHandler _weaponHandler;
    private Enemy enemy;
    
    private bool _canDash = true;
    private bool _dashing = false;
    private Vector2 _dashDir;
    private Animator _animator;
    

    private void Awake()
    {
        _canDash = true;
        stamina = maxStamina;
        _health = healthMax;
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _weaponHandler = GetComponentInChildren<WeaponHandler>();
        Pov.SetActive(true);
    }


    void Update()
    {
        
        LookLeftRight();
        
        _pointerInput = GetMousePos();
        _weaponHandler.MousePos = _pointerInput;
        if (_dashing)
        {
            return;
        }
        stamina += Time.deltaTime * staminaRegenerationRate;
        stamina = Mathf.Clamp(stamina, 0, maxStamina);
        _rb.linearVelocity = _movement * baseSpeed;
        
    }

    private void PerformAttack(InputAction.CallbackContext obj)
    {
        _weaponHandler.Attack();
    }

    public Vector2 GetMousePos()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    
    public void DashKey(InputAction.CallbackContext context)
    {
        if (_canDash && stamina >= dashStaminaUse)
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
            
        }

        _movement = context.ReadValue<Vector2>();
       
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

    private void LookLeftRight()
    {
        MousePos = GetMousePos();   
        Vector2 direction = (MousePos-(Vector2)transform.position).normalized;
        
        
        Vector2 scale = transform.localScale;
        if (direction.x > 0)
        {
            _animator.SetFloat("CurrentX", 1);
        }
        else if (direction.x < 0)
        {
            _animator.SetFloat("CurrentX", -1);
        }
    }
    
}