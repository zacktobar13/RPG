using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour {

    int damageValue = 5;
    public GameObject floatingDamageText;
    public bool redNumbers;


    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag.Equals("Trigger"))
        {
            return;
        }

        other.gameObject.SendMessage("TakeDamage", damageValue, SendMessageOptions.DontRequireReceiver);

        //Vector2 temp = other.transform.position - gameObject.transform.position;
        //other.gameObject.GetComponent<Rigidbody2D>().AddForce(temp.normalized * 5, ForceMode2D.Impulse);

        GameObject text = Instantiate(floatingDamageText, new Vector3(other.transform.position.x, other.transform.position.y + 1.5f, other.transform.position.z), other.transform.rotation);
        Text numbers = text.GetComponentInChildren<Text>();
        numbers.text = damageValue.ToString();
        numbers.color = redNumbers ? Color.red : Color.white;
        //numbers.color = color;
	}
}
