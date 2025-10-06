using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{

    [Header("Ink Story")]
    [SerializeField] private TextAsset inkJson;

    private Story story;
    public bool IsDialoguePlaying => dialoguePlaying;

    private void Awake()
    {
        story = new Story(inkJson.text);
    }

    // Start is called before the first frame update
    private bool dialoguePlaying = false;

    private void OnEnable()
    {
        GameEventsManager.instance.dialogueEvents.onEnterDialogue += EnterDialogue;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.dialogueEvents.onEnterDialogue -= EnterDialogue;
    }


    public void SubmitPressed()
    {
        if (!dialoguePlaying)
        {
            return;
        }
        ContinueOrExitStory();
    }


    private void EnterDialogue(string knotName)
    {
        if (dialoguePlaying)
        {
            return;
        }
        dialoguePlaying = true;

        if (!knotName.Equals(""))
        {
            story.ChoosePathString(knotName);
        }
        else
        {
            Debug.LogWarning("Knot name is empty string! D:");
        }
        ContinueOrExitStory();
        GameEventsManager.instance.dialogueEvents.DialogueStarted();

        PlayerController player = FindObjectOfType<PlayerController>();
        player.BlockMovement();
    }

    private void ContinueOrExitStory()
    {
        if (story.canContinue)
        {
            string dialogueLine = story.Continue();

            GameEventsManager.instance.dialogueEvents.DisplayDialogue(dialogueLine);
        }
        else
        {
            GameEventsManager.instance.dialogueEvents.DialogueFinished();
            StartCoroutine(ExitDialogue());
        }
    }

    private IEnumerator ExitDialogue()
    {
        yield return null;
        dialoguePlaying = false;
        story.ResetState();
        PlayerController player = FindObjectOfType<PlayerController>();
        player.UnblockMovement();
    }
}
