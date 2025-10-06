using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogueEvents
{
    // Start is called before the first frame update
    public event Action<string> onEnterDialogue;

    public void EnterDialogue(string knotName)
    {
        if (onEnterDialogue != null)
        {
            onEnterDialogue(knotName);
        }
    }

    public event Action onDialogueStarted;
    public void DialogueStarted()
    {
        if (onDialogueStarted != null)
        {
            onDialogueStarted();
        }
    }

    public event Action onDialogueFinished;
    public void DialogueFinished()
    {
        if (onDialogueFinished != null)
        {
            onDialogueFinished();
        }
    }

    public event Action<string> onDisplayDialogue;
    public void DisplayDialogue(string dialogueLine)
    {
        if (onDisplayDialogue != null)
        {
            onDisplayDialogue(dialogueLine);
        }
    }
}
