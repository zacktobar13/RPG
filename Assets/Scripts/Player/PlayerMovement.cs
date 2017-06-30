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

	Vector3 xVelocity;
	Vector3 zVelocity;
	Vector3 previous;

	public Animator animator;
	CharacterStats characterStats;

	void Awake() {

		animator = GetComponent<Animator>();
		characterStats = GetComponent<CharacterStats>();

	}

	void Update() {

		// Capturing player input
		leftRight = Input.GetAxis("Horizontal");
		upDown = Input.GetAxis("Vertical");

		// Actual movement
		transform.Translate(Vector3.forward * upDown * movementSpeed * Time.deltaTime);
		transform.Translate(Vector3.right * leftRight * movementSpeed * Time.deltaTime);

		// Capturing movement stats and sending it to CharacterStats component.
		xVelocity.x = (transform.position.x - previous.x) / Time.deltaTime;
		zVelocity.z = (transform.position.z - previous.z) / Time.deltaTime;
		previous = transform.position;

		characterStats.xVelocity = xVelocity.x;
		characterStats.zVelocity = zVelocity.z;

        // Animator control
        if (Mathf.Abs(xVelocity.x) > 0 || Mathf.Abs(zVelocity.z) > 0)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }

        UpdateDirection();
	}

	// First determine which axis is receiving a greater value of input. Then, determine which
	// polarity (left/right, up/down), is occuring within that axis for proper direction handling.
	void UpdateDirection() {
		animator = GetComponentInChildren<Animator>();
		if (Mathf.Abs(zVelocity.z) >= Mathf.Abs(xVelocity.x)) {

			if (zVelocity.z >= .01f) {
				characterStats.ChangeCharacterDirection(CharacterStats.CharacterDirection.Up);
			} else if (zVelocity.z <= -.01f) {
				characterStats.ChangeCharacterDirection(CharacterStats.CharacterDirection.Down);
			}

		} else {

			if (xVelocity.x >= .01f) {
				characterStats.ChangeCharacterDirection(CharacterStats.CharacterDirection.Right);
			} else if (xVelocity.x <= -.01f) {
				characterStats.ChangeCharacterDirection(CharacterStats.CharacterDirection.Left);
			}

		}

	}
}
