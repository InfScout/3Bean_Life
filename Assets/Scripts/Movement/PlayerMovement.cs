using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    
    [SerializeField] private float baseSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        rb.linearVelocity = movement * baseSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true);
        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("lastInputX", movement.x);
            animator.SetFloat("lastInputY", movement.y);
        }
        
        movement = context.ReadValue<Vector2>();
        animator.SetFloat("CurrentX", movement.x);
        animator.SetFloat("CurrentY", movement.y);
    }
}