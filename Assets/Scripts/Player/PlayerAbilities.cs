using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public GameObject portal;

    void Update()
    {
        if(Input.GetButtonDown("CastPortal"))
        {
            CastPortal();
        }
    }

    void CastPortal()
    {
        GameObject newPortal = Instantiate(portal, new Vector3(transform.position.x, transform.position.y, transform.position.z + 4), Quaternion.identity);
        newPortal.GetComponent<Portal>().SetDestination("Tree Town");
    }
}
