using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class Inventory : MonoBehaviour
{
    private const int SLOTS = 6;

    private List<InventoryItem> mItems = new List<InventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public void AddItem(InventoryItem item)
    {
        if (mItems < SLOTS)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enabled)
            {
                collider.enabled = false;
                mItems.Add(item);
                item.OnPickup();

                if (ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventsArgs(item));
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/
