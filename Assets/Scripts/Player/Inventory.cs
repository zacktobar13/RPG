using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    int totalSlots;
    int slotsInUse;

    List<GameObject> items;
    public GameObject inventoryDisplay;
    public InventorySlot[] inventorySlots;
    public InventorySlot[] equipmentSlots;
    
    void Start()
    {
        totalSlots = 16;
        items = new List<GameObject>();

        // TODO: Eventually we'll load in slots from memory
        slotsInUse = 0;
    }
    
    void Update()
    {
        if (PlayerInput.showInventory)
        {
            ShowInventory();
        }
    }

    void ShowInventory()
    {
        #pragma warning disable CS0618 // Type or member is obsolete
        inventoryDisplay.active = !inventoryDisplay.active;
        #pragma warning restore CS0618 // Type or member is obsolete
    }

    public bool AddToInventory(GameObject item)
    {
        if (slotsInUse == totalSlots)
        {
            return false;
        }

        items.Add(item);
        int index = NextAvaliableIndex();
        inventorySlots[index].itemInSlot = item;
        inventorySlots[index].image.sprite = item.GetComponent<SpriteRenderer>().sprite;
        item.SetActive(false);

        slotsInUse++;
        return true;
    }

    public bool RemoveFromInventory(GameObject item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].itemInSlot == item)
            {
                inventorySlots[i].transform.position = this.transform.position;
                inventorySlots[i].itemInSlot.SetActive(true);
                inventorySlots[i].itemInSlot = null;

                //inventorySlots[i].image.sprite = // idk what to put here
            }
        }
        return false;
    }

    //public bool RemoveFromInventory()

    /// <summary>
    /// Returns index of first open slot in inventory
    /// </summary>
    int NextAvaliableIndex()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].itemInSlot == null)
            {
                return i;
            }
        }
        return -1;
    }
}
