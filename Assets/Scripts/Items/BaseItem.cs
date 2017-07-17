using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BaseItem : MonoBehaviour
{
    public string ItemName { get; set; }

    public string Description { get; set; }

    public Type ItemType { get; set; }

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
    /// Two items are considered equal iff they have the same name and seed.
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

    public virtual void RollItemStats(int seed)
    {
        Debug.LogError("Implement RollItemStats in item class, don't rely on BaseItem's!");
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

    /// <summary>
    /// Serializes an item at PATH with its name being the items name + seed.
    /// Saves it in the format: Name\nSeed
    /// Given the Name we can find the prefab, then use the Seed to build up stats.
    /// TODO: Make a more foolproof naming convention (could be collisions now)
    /// </summary>
    public void SaveItem(string path)
    {
        string itemPath = Path.Combine(path, ItemName + Seed.ToString());
        File.Create(itemPath);
        File.AppendAllText(itemPath, ItemName + "\n" + Seed.ToString());
    }
}
