using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    [HideInInspector] public GameObject itemInSlot;
    public Image image;
    public bool isSelected;
    public static Sprite defaultSprite;

    private void Awake()
    {
        image.sprite = defaultSprite;
        itemInSlot = null;
        // TODO: Eventually we'll make these some default image
    }
}
