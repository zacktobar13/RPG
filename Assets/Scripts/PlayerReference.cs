using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class exists so that things who need to find out
/// who the player is can do so in an inexpensive way.
/// </summary>
public static class PlayerReference
{
    public static GameObject player = GameObject.FindGameObjectWithTag("Player");

    public static void RefreshPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
