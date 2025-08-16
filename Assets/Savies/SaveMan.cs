using System.IO;
using Unity.Cinemachine;
using UnityEngine;

public class SaveMan : MonoBehaviour
{
   public string saveLocation;
   public static SaveMan Instance;
   [SerializeField]GameObject player;


   private void Awake()
   {
      if (Instance == null)
         Instance = this;
   }
   void Start()
   {
      player = GameObject.FindGameObjectWithTag("Player");
      saveLocation = Path.Combine(Application.persistentDataPath, "saveFile.json");
   }

   public void Save()
   {
      SaveData saveData = new SaveData();
      {
         saveData.playerPosition = GameObject.Find("Player").transform.position;
         saveData.mapBoundary = FindAnyObjectByType<CinemachineConfiner2D>().BoundingShape2D.gameObject.name;
         saveData.playerHealth = player.GetComponent<Player>()._health;
         saveData.playerStamina = player.GetComponent<Movement>().stamina;
      }
      File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
   }

   public void Load()
   {
      if (File.Exists(saveLocation))
      {
         SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation)); 
         
         GameObject.Find("Player").transform.position = saveData.playerPosition;
         FindAnyObjectByType<CinemachineConfiner2D>().BoundingShape2D = GameObject.Find
         (saveData.mapBoundary).GetComponent<PolygonCollider2D>();
         player.GetComponent<Player>()._health = saveData.playerHealth;
         player.GetComponent<Player>().TakeDMG(0);
         player.GetComponent<Movement>().stamina = saveData.playerStamina; 
         
      }
      else
      {
         Save();
      }
   }
   
}
