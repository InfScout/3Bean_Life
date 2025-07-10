using UnityEngine;

public class PauseMan : MonoBehaviour
{
   public bool isPaused { get;private set; } = false;

   public void SetPaused(bool pause)
   {
      isPaused = pause;
   }
}
