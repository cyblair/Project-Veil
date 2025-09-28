/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class npcScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
  //      playerMoveCode = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
    }
    public TextMeshProUGUI dialogueText;
    //private PlayerControler playerMoveCode;
    int textBoxIndex;

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (textBoxIndex == dialogue.Count)
                {
            //        playerMoveCode.canMove = true;
                    textBoxIndex = 0;
                    dialogueText.text = "";
                }
                else
                {
                    dialogueText.text = dialogue[textBoxIndex];
                    textBoxIndex += 1;
             //       playerMoveCode.canMove = false;
                }
            }
        }
    }
    public List<string> dialogue = new List<string>();


    public bool playerInRange;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

}
*/