using UnityEngine;

public enum NPCStates
{
    Idle,
    Walk,
}

public class BaseNPC : MonoBehaviour  
{
    [Header("Movement")] 
    [SerializeField] private float moveUp = 0f;
    [SerializeField] private float moveDown = 0f;
    [SerializeField] private float moveLeft = 0f;
    [SerializeField] private float moveRight = 0f;
    
   [SerializeField] private NPCStates npcState = NPCStates.Idle;
   [SerializeField] private Transform finalPosition;
   [SerializeField] private Transform startPosition;
    private Rigidbody2D rb;
    private Animator NpcAnimator;
    private float affinity;
    [SerializeField]private float hp;
    private bool dead = false;
    private float waitTime;
    [SerializeField] private float walkSpeed = 2f;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        NpcAnimator = GetComponent<Animator>();
    }
    
   private void Update()
   {
       Move();
       switch (npcState)
       {
           case NPCStates.Idle:
               IdleState();
               break;
           case NPCStates.Walk:
               WalkState();
               break;
       }
   }

   private void IdleState()
   {
       NpcAnimator.SetBool("IsMoving", false);
   }

   private void WalkState()
   {
       NpcAnimator.SetBool("IsMoving", true);
   }
   private void Move()
   {
       transform.position = Vector2.MoveTowards(transform.position,
           new Vector2(finalPosition.position.x, finalPosition.position.y), walkSpeed * Time.deltaTime);
      // transform.position = Vector2.MoveTowards(transform.position,
          // new Vector2(startPosition.position.x, startPosition.position.y), walkSpeed * Time.deltaTime);
          // new Vector2(startPosition.position.x, startPosition.position.y), walkSpeed * Time.deltaTime);
   }
    
}
