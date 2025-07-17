using UnityEngine;

    public class Win :MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                GameMan.Instance.YouWin();
            }
        }
      
    }
