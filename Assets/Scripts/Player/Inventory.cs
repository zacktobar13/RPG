using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    int totalSlots;
    int slotsInUse;
    public float inventoryMovementCooldown;
    float lastMovement;
    int currentSlot;
    Color originalColor;

    List<GameObject> items;
    public GameObject inventoryDisplay;
    public InventorySlot[] inventorySlots;
    public InventorySlot[] equipmentSlots;
    PlayerMovement playerMovement;
    PlayerInteract playerInteract;
    
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInteract = GetComponent<PlayerInteract>();
        originalColor = inventorySlots[0].image.color;
        ShowInventory();
        totalSlots = inventorySlots.Length;
        items = new List<GameObject>();
        currentSlot = 0;

        // TODO: Eventually we'll load in slots from memory
        slotsInUse = 0;
        ShowInventory();
    }
    
    void Update()
    {
        if (PlayerInput.showInventory)
        {
            ShowInventory();
        }

        if (inventoryDisplay.activeSelf && Time.time > lastMovement + inventoryMovementCooldown)
        {
            ChangeSelectedSlot(currentSlot, InventoryNewPosition(currentSlot, PlayerInput.movementHorizontal, PlayerInput.movementVertical));
        }

        if (inventoryDisplay.activeSelf && PlayerInput.interact)
        {
            RemoveFromInventory(inventorySlots[currentSlot]);
        }
    }

    void ShowInventory()
    {
        #pragma warning disable CS0618 // Type or member is obsolete
        inventoryDisplay.active = !inventoryDisplay.active;
        playerMovement.enabled = !inventoryDisplay.active;
        playerInteract.enabled = !inventoryDisplay.active;
        #pragma warning restore CS0618 // Type or member is obsolete

        lastMovement = Time.time;
        ChangeSelectedSlot(currentSlot, 0);
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
                inventorySlots[i].itemInSlot.transform.position = this.transform.position;
                inventorySlots[i].itemInSlot.SetActive(true);
                inventorySlots[i].itemInSlot = null;
                inventorySlots[i].image.sprite = InventorySlot.defaultSprite;
                return true;
            }
        }
        return false;
    }

    public bool RemoveFromInventory(InventorySlot slot)
    {
        Debug.Log("Here");
        if (slot.itemInSlot == null)
        {
            return false;
        }

        slot.itemInSlot.transform.position = this.transform.position;
        slot.itemInSlot.SetActive(true);
        slot.itemInSlot = null;
        slot.image.sprite = InventorySlot.defaultSprite;
        return true;
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

    int InventoryNewPosition(int currentPosition, float xInput, float yInput)
    {
        if (xInput == 0 && yInput == 0)
        {
            return currentPosition;
        }

        int roundedX = InputsToInt(xInput);
        int roundedY = InputsToInt(yInput);

        // TODO: Change this to be more intuitive and less correct.
        return (int)(Mod(Mod(currentPosition + roundedX, totalSlots) + -4 * roundedY, totalSlots));
    }

    float Mod(float a, float b)
    {
        return a - b * Mathf.Floor(a / b);
    }

    void ChangeSelectedSlot(int oldSlot, int newSlot)
    {
        inventorySlots[newSlot].isSelected = true;
        inventorySlots[oldSlot].isSelected = false;

        inventorySlots[oldSlot].image.color = originalColor;
        originalColor = inventorySlots[newSlot].image.color;
        inventorySlots[newSlot].image.color = Color.red;

        currentSlot = newSlot;
        lastMovement = Time.time;
    }

    int InputsToInt(float input)
    {
        if (input < 0)
        {
            return -1;
        }
        if (input > 0)
        {
            return 1;
        }
        return 0;
    }
}
