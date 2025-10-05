using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory Inventory;

    // Start is called before the first frame update
    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");

        foreach (Transform slot in inventoryPanel)
        {
            Image image = slot.GetChild(0).getChild(0).GetComponent<image>();

            // Empty inventory slot found
            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;

                // We'll need to store a reference to our item later!! big chun

                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
