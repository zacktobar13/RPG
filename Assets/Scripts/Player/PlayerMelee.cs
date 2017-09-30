using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour {

    public GameObject meleeRight;
    float meleeCooldown = .25f;
    float lastAttack = 0f;

    void Update () {
        if ((PlayerInput.attackHorizontal != 0) && (Time.time >= lastAttack + meleeCooldown))
        {
            StartCoroutine("MeleeAttack");
        }
	}

    IEnumerator MeleeAttack()
    {
        meleeRight.SetActive(true);
        lastAttack = Time.time;
        yield return new WaitForSeconds(.25f);
        meleeRight.SetActive(false);
    }

}
