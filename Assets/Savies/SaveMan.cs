using System.IO;
using Unity.Cinemachine;
using UnityEngine;

public class SaveMan : MonoBehaviour
{
   public string saveLocation;
   public static SaveMan Instance;
   


   private void Awake()
   {
      if (Instance == null)
         Instance = this;
   }
   void Start()
   {
      saveLocation = Path.Combine(Application.persistentDataPath, "saveFile.json");
   }

   public void Save()
   {
      SaveData saveData = new SaveData();
      {
         saveData.playerPosition = GameObject.Find("Player").transform.position;
         saveData.mapBoundary = FindAnyObjectByType<CinemachineConfiner2D>().BoundingShape2D.gameObject.name;
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
      }
      else
      {
         Save();
      }
   }
   
}
