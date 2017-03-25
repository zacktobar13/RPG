using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDirectionSwitcher : MonoBehaviour {

	[SerializeField]
	GameObject[] spriteContainers;

	void Awake() {

		spriteContainers = new GameObject[4];
		
		for (int i = 0; i <= spriteContainers.Length; i++) {

			switch (i) {
				case 0:
					spriteContainers[i] = GameObject.Find("Facing Down Sprites");
					break;
				case 1:
					spriteContainers[i] = GameObject.Find("Facing Left Sprites");
					break;
				case 2:
					spriteContainers[i] = GameObject.Find("Facing Up Sprites");
					break;
				case 3:
					spriteContainers[i] = GameObject.Find("Facing Right Sprites");
					break;
			}

		}

	}

	public void ChangeSpriteSet(CharacterStats.CharacterDirection direction) {

		foreach(GameObject spriteContainer in spriteContainers) {

			if (spriteContainer.name != "Facing " + direction.ToString() + " Sprites") {
				spriteContainer.SetActive(false);
			} else {
				spriteContainer.SetActive(true);
			}

		}
	}
}
