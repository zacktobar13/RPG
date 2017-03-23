using UnityEngine;
using UnityEngine.UI;

public class ArmorGraphicalDebugGUI : MonoBehaviour {

	public GameObject armorMenu;
	public Toggle[] toggles;
	bool enableArmorMenu = false;

	void Update () {

		// Detecting input for option to display the menu.
		if (Input.GetButtonDown("ArmorGraphicDebugToggle")) {
			enableArmorMenu = !enableArmorMenu;
		}

		// Taking input handled above for toggling armor menu Game Object.
		if (enableArmorMenu) {
			armorMenu.SetActive(true);
		} else {
			armorMenu.SetActive(false);
		}
	}

	// Logic for Equip All button. Turns every toggle on.
	public void EquipAll() {
		foreach (Toggle toggle in toggles) {
			toggle.isOn = true;
		}
	}

	// Logic for Unequip All button. Turns every toggle off.
	public void UnenquipAll() {
		foreach (Toggle toggle in toggles) {
			toggle.isOn = false;
		}
	}
}
