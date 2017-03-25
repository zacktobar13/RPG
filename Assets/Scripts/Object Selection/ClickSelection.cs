using UnityEngine;

public class ClickSelection : MonoBehaviour {

	public ObjectDebugGUI objectDebugGUI;
	public GameObject selectionArrow;
	GameObject selectedObject;

	void Update() {

		if (Input.GetMouseButtonDown(0)) {

			RaycastHit hitInfo = new RaycastHit();
			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

			GameObject oldArrow = GameObject.FindGameObjectWithTag("Selection Arrow");

			if (selectedObject != null) {
				selectedObject.GetComponent<CharacterStats>().selected = false;
			}

			if (oldArrow) {
				Destroy(oldArrow);
			}

			if (hit) {

				if (hitInfo.transform.gameObject.GetComponent<CharacterStats>()) {

					objectDebugGUI.selectedObject = hitInfo.transform.gameObject;
					objectDebugGUI.ShowAllText();

					// Instantiate selection arrow and set it to be child of selection.
					GameObject arrow = Instantiate(selectionArrow, hitInfo.transform);
					arrow.transform.localPosition = new Vector3(0, 0, 1);

					hitInfo.transform.gameObject.GetComponent<CharacterStats>().selected = true;
					selectedObject = hitInfo.transform.gameObject;

				} else {

					objectDebugGUI.HideAllText();

				}
			} else {

				Debug.Log("Your click didn't hit any objects at all.");
			}
		}
	}

	bool CheckIfSelectable(GameObject gameObject) {
		if (gameObject.GetComponent<CharacterStats>() != null) {
			return true;
		} else {
			return false;
		}
	}
}
