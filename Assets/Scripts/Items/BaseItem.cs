using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour
{
    string ItemName { get; set; }

    string Description { get; set; }

    Type ItemType { get; set; }

    int Seed { get; set; }

    public Sprite sprite;

    public void InteractWithPlayer(PlayerAndNearObjects playerAndList)
    {
        playerAndList.player.GetComponent<Inventory>().AddToInventory(gameObject);
        playerAndList.objectsInRange.Remove(gameObject);
    }

    private void Start()
    {
        Seed = Random.Range(0, 1000);
    }

    /// <summary>
    /// Two items are considered equal iff they have the same name
    /// </summary>
    public override bool Equals(object other)
    {
        BaseItem otherItem = other as BaseItem;
        return otherItem != null && this.ItemName == otherItem.ItemName && this.Seed == otherItem.Seed;
    }

    public override int GetHashCode()
    {
        return this.ItemName.GetHashCode() ^ this.Seed;
    }

    public override string ToString()
    {
        return ItemName;
    }

    public enum Type
    {
        Weapon,
        BodyArmor,
        Consumable,
        Helmet,
        Gloves,
        Boots
    }
}
