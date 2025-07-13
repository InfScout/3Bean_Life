using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Npc : MonoBehaviour , IInteratable
{
    public NPCDialogue dialogueData;
    public GameObject dialoguepannel;
    public TMP_Text dialogueText, nameText;
    public Image portraitImage;

    private int _dialogueIndex;
    private bool isTyping , isDialogueActive;
    
    public bool IsInteractable()
    {
        return !isDialogueActive;
    }

    public void Interact()
    {
        if (isDialogueActive)
        {
            NextLine();
        }
        
        else
        {
            StartDialogue();
            Debug.Log("Npc Interacted");
        }
    }


    void StartDialogue()
    {
        isDialogueActive = true;
        _dialogueIndex = 0;
        
        nameText.SetText(dialogueData.npcName);
        portraitImage.sprite = dialogueData.npcPortrait;
        
        dialoguepannel.SetActive(true);
        //pause WIP
        //type line/dialogue
            StartCoroutine(TypeDialogue());
    }
    

    IEnumerator TypeDialogue()
    {
        isTyping = true;
        dialogueText.SetText("");

        foreach (char letter in dialogueData.dialogueLines[_dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }
        isTyping = false;
        
    }
    void NextLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.SetText(dialogueData.dialogueLines[_dialogueIndex]);
            isTyping = false;
        }
        else if (++_dialogueIndex < dialogueData.dialogueLines.Length)
        {
            StartCoroutine(TypeDialogue());
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
        dialogueText.SetText("");
        dialoguepannel.SetActive(false);
        //unpause WIP
    }
}
