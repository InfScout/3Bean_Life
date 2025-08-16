using UnityEngine;

public class pitchController : MonoBehaviour
{
  AudioSource audio;
  GameObject player;

  void Start()
  {
    audio = GetComponent<AudioSource>();
    player = GameObject.FindGameObjectWithTag("Player");
  }

  public void UpdatePitch(float pitch)
  {
    audio.pitch = pitch;
  }

  public void MuteAudio()
  {
    audio.mute = !audio.mute;
  }
}
