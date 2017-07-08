using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    int totalSlots;
    int slotsInUse;

    List<GameObject> items;
    
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
        Debug.Log("Inventory Items: " + items.ToString());
    }

    public bool AddToInventory(GameObject item)
    {
        if (slotsInUse == totalSlots)
        {
            return false;
        }

        Debug.Log("Adding " + item.name + " to inventory! " + (totalSlots - slotsInUse).ToString() + " slots left.");
        items.Add(item);
        slotsInUse++;
        return true;
    }
}
