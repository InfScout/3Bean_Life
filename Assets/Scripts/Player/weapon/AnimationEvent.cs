using UnityEngine;
using UnityEngine.Events;

public class AnimationEvent : MonoBehaviour
{
   public UnityEvent OnAttack;

   public void triggerAttack()
   {
      OnAttack?.Invoke();
   }
}
