using UnityEngine;
using UnityEngine.UI;

public class ObjectDebugGUI : MonoBehaviour {

	[HideInInspector]
	public GameObject selectedObject = null;
	public Text hierarchyNameText;
	public Text typeText;
	public Text classText;
	public Text directionText;
	public Text velocityText;

	CharacterStats characterStats;

	public void ShowAllText() {

		foreach (Transform child in transform) {
			child.gameObject.SetActive(true);
		}

		UpdateStaticInfo();
	}

	public void HideAllText() {

		foreach (Transform child in transform) {
			child.gameObject.SetActive(false);
		}
	}

	public void UpdateStaticInfo() {

		if (selectedObject != null) {

			characterStats = selectedObject.GetComponent<CharacterStats>();

			if (selectedObject.GetComponent<CharacterStats>() != null) {
				hierarchyNameText.text = "Hierarchy Name: " + selectedObject.name;
				typeText.text = "Object Type: " + characterStats.characterType;
				classText.text = "Class: " + characterStats.characterClass;
				directionText.text = "Direction: " + characterStats.characterDirection;
			}

		}

	}

	public void UpdateVelocity(float xVelocity, float zVelocity) {
		velocityText.text = "X Velocity: " + xVelocity.ToString("F3") + "\nZ Velocity: " + zVelocity.ToString("F3");
	}
}
