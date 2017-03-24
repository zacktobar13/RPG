using UnityEngine;

public class SmoothTrackTarget : MonoBehaviour {

	[Tooltip("What you're tryna look at you goob.")]
	[SerializeField]
	Transform target;

	[Tooltip("Value for how far back camera will sit.")]
	[SerializeField]
	float zAxisOffset = -14;

	[Tooltip("Smaller number means slower camera tracking.")]
	[SerializeField]
	float smoothSpeed;

	// Logic is placed in LateUpdate to ensure it occurs after player movement
	// which is located in Update.
	void LateUpdate () {
		
		// Create a reference to our current position and our target goal.
		Vector3 currentPosition = transform.position;
		Vector3 desiredPosition = target.position;

		// Calculating interpolation of X axis between our current and target values.
		currentPosition.x = transform.position.x;
		currentPosition.x = currentPosition.x + (smoothSpeed * (desiredPosition.x - currentPosition.x));

		// Calculating interpolation of Z axis between our current and target values.
		currentPosition.z = transform.position.z;
		currentPosition.z = currentPosition.z + (smoothSpeed * ((desiredPosition.z + zAxisOffset) - currentPosition.z));

		// Applying our calculated interpolation to our camera transform.
		transform.position = currentPosition;
	}
}
