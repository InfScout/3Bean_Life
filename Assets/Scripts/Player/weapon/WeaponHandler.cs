using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
  public Vector2 MousePos { get; set; }
  [SerializeField] private Animator animator;
  [SerializeField] private float delay;
  private bool canAttack;
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
      {
          
      //Wip
      }
  }

  IEnumerator AttackCooldown()
  {
      yield return new WaitForSeconds(delay);
      canAttack = true;
  }
  
}
