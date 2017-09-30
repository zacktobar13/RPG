using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    [HideInInspector] public GameObject itemInSlot;
    public string itemName;
    public string itemDescription;
    public string itemPath;
    public Image image;
    public bool isSelected;
    public static Sprite defaultSprite;

    private void Awake()
    {
        image.sprite = defaultSprite;
        itemInSlot = null;
        // TODO: Eventually we'll make these some default image
    }

    public bool RemoveItemFromSlot()
    {
        itemInSlot.transform.position = this.transform.position;
        itemInSlot.SetActive(true);
        itemInSlot = null;
        image.sprite = InventorySlot.defaultSprite;
        return true;
    }

    public bool AddToSlot(GameObject item)
    {
        itemInSlot = item;
        DontDestroyOnLoad(item);
        BaseItem itemComponent = item.GetComponent(typeof(BaseItem)) as BaseItem;
        itemName = itemComponent.ItemName;
        itemDescription = itemComponent.Description;
        itemPath = itemComponent.SaveItem(Inventory.inventorySavePath);
        image.sprite = itemComponent.sprite;
        item.SetActive(false);
        return true;
    }
}
