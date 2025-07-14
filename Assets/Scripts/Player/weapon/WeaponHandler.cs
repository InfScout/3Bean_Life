using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
  public Vector2 MousePos { get; set; }

  private void Update()
  {
    transform.right = (MousePos-(Vector2)transform.position ).normalized;
  }
}
