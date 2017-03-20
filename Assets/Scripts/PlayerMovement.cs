using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** This class reaches out to the Player Input game object and applies basic movement
  * based off of that. The names and properties of our Input axes and buttons are found in
  * Edit >> Project Settings >> Input. */

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	float movementSpeed;

	float upDown;
	float leftRight;

	void Update() {

		leftRight = Input.GetAxis("Horizontal");
		upDown = Input.GetAxis("Vertical");

		transform.Translate(Vector3.forward * upDown * movementSpeed * Time.deltaTime);

		transform.Translate(Vector3.right * leftRight * movementSpeed * Time.deltaTime);
	}
}
