using System.Collections;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{

    public GameObject meleeUp;
    public GameObject meleeRight;
    public GameObject meleeDown;
    public GameObject meleeLeft;

    float meleeCooldown = .5f;
    float lastAttack = 0f;

    void Update ()
    {
        if ((PlayerInput.attackHorizontal != 0 || PlayerInput.attackVertical != 0) && (Time.time >= lastAttack + meleeCooldown))
        {
            lastAttack = Time.time;

            if (PlayerInput.attackHorizontal > .25)
            {
                StartCoroutine("MeleeAttack", meleeRight);
            }
            else if (PlayerInput.attackHorizontal < -.25)
            {
                StartCoroutine("MeleeAttack", meleeLeft);
            }
            else if (PlayerInput.attackVertical < -.25)
            {
                StartCoroutine("MeleeAttack", meleeDown);
            }
            else if (PlayerInput.attackVertical > .25)
            {
                StartCoroutine("MeleeAttack", meleeUp);
            }
        }
	}

    IEnumerator MeleeAttack(GameObject damageField)
    {
        damageField.SetActive(true);
        yield return new WaitForSeconds(.25f);
        damageField.SetActive(false);
    }
}
