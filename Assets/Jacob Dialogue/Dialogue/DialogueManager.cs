using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{

    [Header("Ink Story")]
    [SerializeField] private TextAsset inkJson;

    public Story story;
    public static DialogueManager Instance;

    private int currentChoiceIndex = -1;

    public bool IsDialoguePlaying => dialoguePlaying;

    private void Awake()
    {
        Instance = this;
        story = new Story(inkJson.text);
    }

    // Start is called before the first frame update
    private bool dialoguePlaying = false;

    private void OnEnable()
    {
        GameEventsManager.instance.dialogueEvents.onEnterDialogue += EnterDialogue;
        GameEventsManager.instance.dialogueEvents.onUpdateChoiceIndex += UpdateChoiceIndex;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.dialogueEvents.onEnterDialogue -= EnterDialogue;
        GameEventsManager.instance.dialogueEvents.onUpdateChoiceIndex -= UpdateChoiceIndex;
    }

    private void UpdateChoiceIndex(int choiceIndex)
    {
        this.currentChoiceIndex = choiceIndex;
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
        if (story.currentChoices.Count > 0 && currentChoiceIndex != -1)
        {
            story.ChooseChoiceIndex(currentChoiceIndex);
            currentChoiceIndex = -1;
        }



        if (story.canContinue)
        {
            string dialogueLine = story.Continue();

            GameEventsManager.instance.dialogueEvents.DisplayDialogue(dialogueLine, story.currentChoices);
        }
        else if (story.currentChoices.Count == 0)
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
