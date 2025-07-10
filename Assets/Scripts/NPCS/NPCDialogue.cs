using UnityEngine;

[CreateAssetMenu(fileName = "NPCS", menuName = "NPC Dialogue")]
public class NPCDialogue : ScriptableObject
{
    public string npcName;
    public Sprite npcPortrait;
    public string[] dialogueLines ;
    public float typingSpeed = 0.05f;
    public AudioClip npcSound;
    public float voicePitch = 0.9f;
    
}
