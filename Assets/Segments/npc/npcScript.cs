using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class npcScript : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    private PlayerController player;
    int textBoxIndex;
    
    public List<string> dialogue = new List<string>();
    
    public bool playerInRange;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (textBoxIndex == dialogue.Count)
                {
                    player.BlockMovement();
                    textBoxIndex = 0;
                    dialogueText.text = "";
                }
                else
                {
                    dialogueText.text = dialogue[textBoxIndex];
                    textBoxIndex += 1;
                    player.UnblockMovement();
                }
            }
        }
    }
    
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
