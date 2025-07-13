using Unity.Cinemachine;
using UnityEngine;

public class MapTransition : MonoBehaviour
{
   [SerializeField] PolygonCollider2D mapBoundary;
   CinemachineConfiner2D confiner;
   [SerializeField] Direction direction;
   enum Direction { Up, Down, Left, Right }
   private void Awake()
   {
      confiner = FindObjectOfType<CinemachineConfiner2D>();
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.gameObject.CompareTag("Player"))
      {
         confiner.BoundingShape2D = mapBoundary;
      }
   }
   
}
