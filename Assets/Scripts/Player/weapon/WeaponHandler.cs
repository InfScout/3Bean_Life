using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
  public Vector2 MousePos { get; set; }
  [SerializeField] private Animator animator;
  [SerializeField] private float delay;
  private bool canAttack;
  [SerializeField] private GameObject player;
  
  [SerializeField] private Transform circleOrigin;
  [SerializeField] private float radius;
  [SerializeField] private float damage = 3;
  
  private void Update()
  {
    Vector2 direction = (MousePos-(Vector2)transform.position).normalized;
    transform.right = direction;
    
    Vector2 scale = transform.localScale;
    
    if (direction.x < 0)
    {
        scale.y = -1;
    }
    else if (direction.x > 0)
    {
        scale.y = 1;
    }
    transform.localScale = scale;
  }
    
  public void Attack()
  {
      if (canAttack)
          return;
      animator.SetTrigger("Attack");
      canAttack = true;
      StartCoroutine(AttackCooldown());

  }

  IEnumerator AttackCooldown()
  {
      yield return new WaitForSeconds(delay);
      canAttack = false;
  }

  private void OnDrawGizmosSelected()
  {
      Gizmos.color = Color.green;
      Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
      Gizmos.DrawWireSphere(position, radius);
  }

  public void DetectCollision()
  {
      foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
      {
          Health health;
          Debug.Log(collider.name);
          if (health = collider.GetComponent<Health>())
          {
              health.GetHit(damage, player);
          }
      }
  }
  
}
