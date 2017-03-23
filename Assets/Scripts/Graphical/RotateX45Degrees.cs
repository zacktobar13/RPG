using UnityEngine;

// Rotates sprite container 45 degrees on start to properly face the camera. This
// is required because all animations must be initially created with a rotation of
// 0 degrees within the editor and this automates the necessity of manually inputting
// the proper rotation every time we want to run the game to test animations.

public class RotateX45Degrees : MonoBehaviour {

	void Start () {
		transform.Rotate(45, 0, 0);
	}

}
