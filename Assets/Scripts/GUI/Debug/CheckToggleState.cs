using UnityEngine;
using UnityEngine.UI;

public class CheckToggleState : MonoBehaviour {

	public SpriteRenderer sprite;

	Toggle toggle;

	// Sets up reference to Toggle component and determines if its checkmark should
	// be on or off on start up depending on if its corresponding Sprite Renderer
	// component is initially enabled or disabled.
	void Awake () {

		toggle = GetComponent<Toggle>();

		if (sprite.enabled) {
			toggle.isOn = true;
		} else {
			toggle.isOn = false;
		}
	}

	// Checks every frame if Toggle component's corresponding Sprite Renderer should
	// be enabled or disabled based on current Toggle state.
	void Update() {
		if (toggle.isOn) {
			sprite.enabled = true;
		} else {
			sprite.enabled = false;
		}
	}

}
