    using UnityEngine;


    public class EnemyDetection : MonoBehaviour
    {
        public bool AwarePlayer { get; private set; }
        
        public Vector2 PlayerPos { get; private set; }
        
        [SerializeField]
        private float detectDistance;
        private Transform player;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

    }
