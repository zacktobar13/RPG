using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingDamageText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("KillYourself");
	}

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + .02f, transform.position.z);
    }
    
    IEnumerator KillYourself() {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
	}
}
