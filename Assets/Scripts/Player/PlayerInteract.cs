﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    List<GameObject> objectsInRange;

    private void Start()
    {
        objectsInRange = new List<GameObject>();
    }

    void Update()
    {
        if (PlayerInput.interact)
        {
            InteractWithNearestObject();
        }
    }

    void InteractWithNearestObject()
    {
        GameObject nearestObject = Utils.FindNearestObject(gameObject, objectsInRange);
        if (nearestObject)
        {
            PlayerAndNearObjects playerAndList = new PlayerAndNearObjects(gameObject, objectsInRange);
            nearestObject.SendMessage("InteractWithPlayer", playerAndList);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            objectsInRange.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            objectsInRange.Remove(other.gameObject);
        }
    }
}

public class PlayerAndNearObjects
{
    public GameObject player;
    public List<GameObject> objectsInRange;

    public PlayerAndNearObjects(GameObject p, List<GameObject> obj)
    {
        player = p;
        objectsInRange = obj;
    }
}
