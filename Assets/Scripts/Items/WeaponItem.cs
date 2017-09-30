using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponItem : BaseItem
{

    public int damage;

    public override void RollItemStats(int seed)
    {
        damage = seed % 100;
    }
}
