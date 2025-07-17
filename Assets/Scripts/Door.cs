using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Door:MonoBehaviour
    {
        [SerializeField]private Transform destination;
        [SerializeField]private GameObject player;
        [SerializeField] PolygonCollider2D mapBoundary;
        CinemachineConfiner2D confiner;
        private void Awake()
        {
            confiner = FindObjectOfType<CinemachineConfiner2D>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                player.transform.position = destination.position;
                confiner.BoundingShape2D = mapBoundary;
            }
        }
        
    }
