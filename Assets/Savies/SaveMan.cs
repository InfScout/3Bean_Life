using System.IO;
using Unity.Cinemachine;
using UnityEngine;

public class SaveMan : MonoBehaviour
{
   private string saveLocation;

   void Start()
   {
      saveLocation = Path.Combine(Application.persistentDataPath, "saveFile.json");
   }

   public void Save()
   {
      SaveFile saveFile = new SaveFile();
      {
         saveFile.playerPosition = GameObject.Find("Player").transform.position;
         saveFile.mapBoundary = FindAnyObjectByType<CinemachineConfiner2D>().BoundingShape2D.gameObject.name;
      }
      File.WriteAllText(saveLocation, JsonUtility.ToJson(saveFile));
   }

   public void Load()
   {
      if (File.Exists(saveLocation))
      {
         SaveFile saveFile = JsonUtility.FromJson<SaveFile>(File.ReadAllText(saveLocation)); 
         
         GameObject.Find("Player").transform.position = saveFile.playerPosition;
         
         FindAnyObjectByType<CinemachineConfiner2D>().BoundingShape2D = GameObject.Find
         (saveFile.mapBoundary).GetComponent<PolygonCollider2D>();
      }
      else
      {
         Save();
      }
   }
   
}
