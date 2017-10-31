using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour {

    public GameObject meleeRight;
    float meleeCooldown = .5f;
    float lastAttack = 0f;

    void Update () {
        if ((PlayerInput.attackHorizontal != 0) && (Time.time >= lastAttack + meleeCooldown))
        {
            lastAttack = Time.time;
            StartCoroutine("MeleeAttack");
        }
	}

    IEnumerator MeleeAttack()
    {
        meleeRight.SetActive(true);
        yield return new WaitForSeconds(.25f);
        meleeRight.SetActive(false);
    }

}
