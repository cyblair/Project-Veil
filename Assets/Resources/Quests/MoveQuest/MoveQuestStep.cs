using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveQuest : MonoBehaviour
{
    private bool questCompleted = false;
    private void OnEnable()
    {
        //playerMovement.isMoving += CompleteQuest;
    }

    private void OnDisable()
    {
        //playerMovement.isMoving -= CompleteQuest;
    }

    private void CompleteQuest()
    {
        if (!questCompleted)
        {
            questCompleted = true;
        }
    }

}
