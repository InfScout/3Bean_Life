using UnityEngine;

public class AudioMan : MonoBehaviour
{
   public static AudioMan instance;
   
   [SerializeField] private AudioSource soundObj;
   private void Awake()
   {
      if (instance == null)
         instance = this;
   }

   public void PlaySound(AudioClip audioClip, Transform spawnLocation, float volume, float pitch)
   {
      AudioSource audioSource = Instantiate(soundObj, spawnLocation.position, Quaternion.identity);
      
      audioSource.clip = audioClip;
      
      audioSource.volume = volume;
      
      audioSource.pitch = pitch;
      
      audioSource.Play();
      
      float clipLength = audioSource.clip.length;
      Destroy(audioSource.gameObject, clipLength);
   }
}
