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
    private bool _isTyping , _isDialogueActive;
    
    public bool IsInteractable()
    {
        return !_isDialogueActive;
    }

    public void Interact()
    {
        if (_isDialogueActive)
        {
            NextLine();
        }
        
        else
        {
            StartDialogue();
        }
    }


    void StartDialogue()
    {
        _isDialogueActive = true;
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
        _isTyping = true;
        dialogueText.SetText("");

        foreach (char letter in dialogueData.dialogueLines[_dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }
        _isTyping = false;
        
    }
    void NextLine()
    {
        if (_isTyping)
        {
            StopAllCoroutines();
            dialogueText.SetText(dialogueData.dialogueLines[_dialogueIndex]);
            _isTyping = false;
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
        _isDialogueActive = false;
        dialogueText.SetText("");
        dialoguepannel.SetActive(false);
        //unpause WIP
    }
}
