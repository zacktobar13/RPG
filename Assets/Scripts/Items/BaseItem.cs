using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class BaseItem : MonoBehaviour
{
    public string ItemName;

    public string Description;

    public Type ItemType;

    int Seed;

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
        return string.Concat(ItemName, " : ", Seed);
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
    /// Serializes an item at PATH with its name being the itemName:Seed.
    /// Saves it in the format: Name\nSeed
    /// Given the Name we can find the prefab, then use the Seed to build up stats.
    /// TODO: Make a more foolproof naming convention (could be collisions now)
    /// </summary>
    public string SaveItem(string path)
    {
        string itemPath = Path.Combine(path, string.Concat(ItemName, "-", Seed.ToString()));
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        File.Create(itemPath).Close();
        return itemPath;
    }
}
