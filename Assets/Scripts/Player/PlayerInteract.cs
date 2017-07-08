using System.Collections;
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
            nearestObject.SendMessage("InteractWithPlayer", gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            Debug.Log(other.name);
            objectsInRange.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            objectsInRange.Remove(other.gameObject);
        }
    }
}
