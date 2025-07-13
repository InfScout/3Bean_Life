using System;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class MapTransition : MonoBehaviour
{
   [SerializeField] PolygonCollider2D mapBoundary;
   CinemachineConfiner2D _confiner;
   /*[SerializeField] Direction direction;
   enum Direction { Up, Down, Left, Right }*/
   
   private void Awake()
   {
      _confiner = GetComponent<CinemachineConfiner2D>();
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.gameObject.CompareTag("Player"))
      {
         _confiner.BoundingShape2D = mapBoundary;
      }
   } 

   /*private void UpdatePlayerLocation(GameObject player)
   {
      Vector3 newPosition = player.transform.position;
      switch (direction)
      {
         case Direction.Up:
            newPosition.y += 8;
            break;
         case Direction.Down:
            newPosition.y -= 8;
            break;
         case Direction.Left:
            newPosition.x -= 8;  
            break;   
         case Direction.Right:
            newPosition.x += 8;
            break;   
      }
      player.transform.position = newPosition;
   }*/
}
