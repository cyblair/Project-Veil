using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("Dialogue (optional)")]
    [SerializeField] private string dialogueKnotName;

    void Interact(GameObject source)
    {
        source.GetComponent<Animator>().SetFloat("MoveMagnitude", 0);

        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        if (dialogueManager == null)
            return;

        if (dialogueManager.IsDialoguePlaying)
        {
            dialogueManager.SubmitPressed();
        }
        else
        {
            if (!string.IsNullOrEmpty(dialogueKnotName))
            {
                GameEventsManager.instance.dialogueEvents.EnterDialogue(dialogueKnotName);
            }
        }
    }
}
