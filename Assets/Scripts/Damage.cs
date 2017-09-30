using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
        other.gameObject.SendMessage("TakeDamage", 5);
	}
}
